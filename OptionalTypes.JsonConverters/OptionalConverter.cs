using System;
using System.Reflection;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OptionalTypes.JsonConverters
{
    public class OptionalConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            var optional = value as IOptional;

            if (optional == null)
            {
                writer.WriteNull();
                return;
            }

            if (!optional.IsDefined)
            {
                writer.WriteUndefined();
                return;
            }

            writer.WriteValue(optional.Value);
        }

        public override object ReadJson(JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
         
            var existingOptional = existingValue as IOptional;

            // Return null, because the Optional is a struct, it will be created as a non-null
            // string with isDefined set to false.
            if (reader.TokenType == JsonToken.Undefined)
                return null;


            if (existingOptional == null)
                return null;

            var value = reader.Value;

            var underlyingType = existingOptional.GetUnderlyingType();

            if (value == null)
            {
                var baseType = existingOptional.GetBaseType();
                if (baseType.GetTypeInfo().IsValueType)
                    if (!(baseType.GetTypeInfo().IsGenericType && baseType.GetGenericTypeDefinition().Equals(typeof(Nullable<>))))
                        throw new InvalidCastException($"Cannot convert null to a {existingOptional.GetBaseType()} because it does not allow null values.");
            }

            if (value != null && value.GetType() != underlyingType)
                try
                {
                    value = Convert.ChangeType(value, underlyingType);
                }
                catch (Exception e)
                {
                    throw new InvalidCastException($"Cannot convert {reader.Value} to a {existingOptional.GetBaseType()} because of {e.Message}", e);
                }

            //if something
            value = Activator.CreateInstance(underlyingType);
            var optionalObject = (IOptional)Activator.CreateInstance(objectType, value);
            //  if (reader.Curr = Start)
            //  {
          
            var jObject = JObject.Load(reader);
              serializer.Populate(jObject.CreateReader(), optionalObject.Value );
            //}

            
            return optionalObject;
        }

        public override bool CanConvert(Type objectType)
        {
            //TODO: find a better way
            return objectType.Name == typeof(Optional<>).Name;
        }
    }
}