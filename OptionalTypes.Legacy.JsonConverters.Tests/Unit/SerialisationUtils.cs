using System.IO;
using Newtonsoft.Json;

namespace OptionalTypes.JsonConverters.Tests.Unit
{
    public static class SerialisationUtils
    {
        public static StringWriter SerializeDto(object dto)
        {
            var jsonSerializer = new JsonSerializer();

            jsonSerializer.Converters.Add(new OptionalConverter());
            var stringWriter = new StringWriter();
            JsonWriter jsonWriter = new JsonTextWriter(stringWriter);

            jsonSerializer.Serialize(jsonWriter, dto);

            return stringWriter;
        }

        public static T Deserialize<T>(string json)
        {
            var jsonSerializer = new JsonSerializer();
            jsonSerializer.Converters.Add(new OptionalConverter());
            var stringReader = new StringReader(json);
            JsonReader jsonReader = new JsonTextReader(stringReader);


            return jsonSerializer.Deserialize<T>(jsonReader);
        }
    }
}