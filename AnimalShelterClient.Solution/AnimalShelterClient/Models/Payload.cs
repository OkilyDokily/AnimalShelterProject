using System.Text.Json;
using System;
using Microsoft.AspNetCore.Http;

namespace AnimalShelterClient.Models
{
  public class Payload
  {
    public int exp { get; set; }
    public string aud { get; set; }
    public string iss { get; set; }

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
      return base64EncodedData.Split(".")[1];
    }
    
    public static Payload ReturnPayloadFromHeader(string header)
    {
      return GetPayload(Base64Decode(ExtractPayLoad(header)));
    }
    
    public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
    {
      // Unix timestamp is seconds past epoch
      DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
      dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
      return dtDateTime;
    }
    
    public static (bool, bool) GetValues(HttpContext context)
    {
      try
      {
        string cookie = context.Request.Cookies["JWT"];
  
        string payloadportion = ExtractPayLoad(cookie);
        string convertedpayloadportion = Base64Decode(payloadportion);

        Payload payload = GetPayload(convertedpayloadportion);

        DateTime dateTime = UnixTimeStampToDateTime(payload.exp);

        bool PastDue = (DateTime.Now > dateTime);
        if (!PastDue)
        {

          return (true, true);
        }
        else
        {
          return (true, false);
        }

      }
      catch
      {
        return (false, false);
      }
    }
  }
}