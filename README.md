# OptionalTypes
An Optional&lt;T> type for DotNet that allows you to tell the difference between Null and 'Not Supplied'.

This makes it easier to produce backwards compatible APIs.


### Why?
When building APIs, it's often useful to be able to distinguish between an explicit null value (no value entered by the user) and not supplied by the client application.

Unfortunately, the standard DotNet dto & binding patterns make this very difficult to achieve.

#### Example
Consider a simple contact management API that accepts the following JSON packet.
```javascript
{
    "firstName" : "Bob",
    "lastName" : "Smith"
}
```
Which is represented in the following model:

```csharp
public class ContactDto()
{
    public string FirstName {get; set;}
    public string LastName {get; set;}
}
```
It's probably backed by a domain class that looks similar to this:

```csharp
public class Contact()
{
    public int Id {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
}
```

Somewhere, there will be some mapping code that looks similar to this:

```csharp
public static void MapDtoToContact(ContactDto contactDto, Contact entity)
{
    entity.FirstName = contactDto.FirstName;
    entity.LastName = contactDto.LastName;
}
```

We get a new requirement to support Date of Birth, which is nullable. Ie, the user can choose to supply it or not. 


We add a new property to our dto, 
```csharp
    public DateTime? DateofBirth {get; set;}
```
The old clients of the API have not modified their software yet so they send through the following:

```javascript
{
    "firstName" : "Bob",
    "lastName" : "Smith"
}
```

The newer clients have modified their software and send through the following:

```javascript
{
    "firstName" : "Bob",
    "lastName" : "Smith",
    "dateOfBirth" : null
}
```

The problem is that there is no way to tell in the dto if dateOfBirth is null because the client does not support it,
or because the end user intends it to be null.

The behaviour we want is that if dateOfBirth was supplied then update the value in the database (even if it's an update to null). If it was not supplied then leave it alone.

There are several solutions to this
* Accept JSON patch documents.
* Use API versioning
* Use special values to indicate intentional null.

All of these solutions have drawbacks in terms of additional complexity.

What would be nice is to just add the properties in a backwards compatible manner. 

```csharp
public class ContactDto()
{
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public Optional<DateTime?> DateOfBirth {get; set;}

}
```

With our mapping looking something like
```csharp
entity.DateOfBirth = contactDto.DateOfBirth.IsDefined ? contactDto.DateOfBirth.Value : entity.DateOfBirth;
```
or, more simply:
```csharp
entity.DateOfBirth = contactDto.DateOfBirth.GetValueOrDefault(entity.DateOfBirth);
```
In the semver world, we would call this a minor release as it's backwards compatible with the previous version. 

Of course, we will still need API versioning, but this is only needed for major releases that are no longer backwards compatible.

### How?

#### Installation

##### Web API

Upgrade to the latest NewtonSoft.JSON package via NuGet.
Add the following to your Application_Start method in Global.asax.cs 
```csharp
	HttpConfiguration config = GlobalConfiguration.Configuration;
	config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new OptionalConverter());
```


##### DotNet Core

Add the following to your ConfigureServices method in Startup.cs 
```csharp
	services.AddMvc().AddJsonOptions( o => o.SerializerSettings.Converters.Add(new OptionalConverter()));
```

#### Equality Rules
Two Optional<T> values are considered equal if T is of the same type AND both of their values are undefined or equal.


### What?
This project contains
* The underlying Optional generic type as a NetStandard 1.0 library.
* A JsonConverter compatible with DotNet Core & Web API.
* A sample DotNet Core application using Swagger as a front-end.
* A sample WebAPI application using Swagger as a front-end.

# Legacy
OptionalTypes.Legacy is a NET461 package which uses NewtonSoft.Json 6.3 to make it compatable with older code bases.

