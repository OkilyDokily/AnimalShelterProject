using System.Text.Json;
using System.Text.Json.Serialization;

namespace AnimalShelterAPI.Models
{
    public class Payload
    {
        public int exp {get;set;}
        public string aud {get;set;}
        public string iss {get;set;}

        public static Payload GetPayload(string jsonString)
        {
           return JsonSerializer.Deserialize<Payload>(jsonString);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string ExtractPayLoad(string base64EncodedData)
        {
            return base64EncodedData.Split(" ")[1].Split(".")[1];
        }

        public static Payload ReturnPayloadFromHeader(string header)
        {
          return GetPayload(Base64Decode(ExtractPayLoad(header)));
        }
    }
}