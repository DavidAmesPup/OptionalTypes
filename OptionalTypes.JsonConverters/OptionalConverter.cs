using System;
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
            if (reader.TokenType== JsonToken.Undefined)
                return null;


            object value = reader.Value;

            if (value != null && value.GetType() != existingOptional.GetBaseType())
                value =  Convert.ChangeType(value, existingOptional.GetBaseType());

            return Activator.CreateInstance(objectType, value);
            
        }

        public override bool CanConvert(Type objectType)
        {
            //TODO: find a better way
            return objectType.Name == typeof(Optional<>).Name;
        }
    }
}