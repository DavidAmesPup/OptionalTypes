using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OptionalTypes.JsonConverters.Tests.Unit
{
    public static class SerialisationUtils
    {
        public  static StringWriter SerializeDto(object dto)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
           
            jsonSerializer.Converters.Add(new OptionalConverter());
            StringWriter stringWriter = new StringWriter();
            JsonWriter jsonWriter = new JsonTextWriter(stringWriter);

            jsonSerializer.Serialize(jsonWriter, dto);

            return stringWriter;

        }

        public static T Deserialize<T>(string json)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Converters.Add(new OptionalConverter());
            StringReader stringReader = new StringReader(json);
            JsonReader jsonReader = new JsonTextReader(stringReader);


           return jsonSerializer.Deserialize<T>(jsonReader);

        }
    }
}
