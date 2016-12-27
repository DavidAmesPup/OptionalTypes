using System;
using Newtonsoft.Json;

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
            //  return Convert.ChangeType(existingValue, contract.NonNullableUnderlyingType);

            //TODO: cast value to the underlying type, eg, Long to int
            var target = Activator.CreateInstance(objectType, reader.Value);

            return target;
        }

        public override bool CanConvert(Type objectType)
        {
            //TODO: find a better way
            return objectType.Name == typeof(Optional<>).Name;
        }
    }
}