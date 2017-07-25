using System;
using System.Reflection;
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
            Type targetOptionalType,
            object existingValue,
            JsonSerializer serializer)
        {
            //Ensure that we are getting an Optional to convert to, otherwise it's not for us.
            var existingOptional = existingValue as IOptional;
            if (existingOptional == null)
                return null;

            var underlyingType = existingOptional.GetUnderlyingType();

            switch (reader.TokenType)
            {
                case JsonToken.Undefined:
                    // Return null. because the Optional is a struct, it will be created as a non-null instance with isDefined set to false and default value depending on its underlying type.
                    return null;

                case JsonToken.StartObject:
                    return GetNestedObjectValue(reader, targetOptionalType, serializer, underlyingType);

                case JsonToken.StartArray:
                    var jArray = JArray.Load(reader);
                    var value = Activator.CreateInstance(underlyingType);
                    serializer.Populate(jArray.CreateReader(), value);
                    return Activator.CreateInstance(targetOptionalType, value);


                default:
                    return GetSimpleValue(reader, targetOptionalType, existingOptional, underlyingType);
            }
        }

        private static object GetSimpleValue(JsonReader reader,
            Type targetOptionalType,
            IOptional existingOptional,
            Type targetUnderlyingType)
        {
            var value = reader.Value;
            if (value == null)
            {
                var baseType = existingOptional.GetBaseType();
                if (baseType.GetTypeInfo().IsValueType)
                    if (!(baseType.GetTypeInfo().IsGenericType && baseType.GetGenericTypeDefinition().Equals(typeof(Nullable<>))))
                        throw new InvalidCastException($"Cannot convert null to a {existingOptional.GetBaseType()} because it does not allow null values.");
            }

            if (value != null && value.GetType() != targetUnderlyingType)
                value = ConvertValue(targetUnderlyingType, value, existingOptional);

            return Activator.CreateInstance(targetOptionalType, value);
        }

        private static object GetNestedObjectValue(JsonReader reader,
            Type targetOptionalType,
            JsonSerializer serializer,
            Type targetUnderlyingType)
        {

            var jObject = JObject.Load(reader);
            var value = Activator.CreateInstance(targetUnderlyingType);
            serializer.Populate(jObject.CreateReader(), value);
            return Activator.CreateInstance(targetOptionalType, value);
        }

        private static object ConvertValue(Type targetType,
            object value,
            IOptional existingOptional)
        {

            if (targetType == typeof(Guid))
                try
                {

                    return Guid.Parse((string) value);
                }
                catch (Exception)
                {
                    throw new CannotCreateGuidException(value);
                }

            if (targetType.GetTypeInfo().IsEnum)
                try
                {
                    return Enum.Parse(targetType, (string) value, true);
                }
                catch (Exception)
                {
                    throw new CannotCreateEnumException(value, targetType);
                }
            try
            {
                return Convert.ChangeType(value, targetType);
            }
            catch (Exception e)
            {
                throw new InvalidCastException($"Cannot convert {value} to a {existingOptional.GetBaseType()} because of {e.Message}", e);
            }

        }
   

public override bool CanConvert(Type objectType)
        {
            if (!objectType.GetTypeInfo().IsGenericType)
                return false;

            return objectType.GetGenericTypeDefinition() == typeof(Optional<>);
        }
    }
}