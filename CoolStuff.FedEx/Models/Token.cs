using CoolStuff.Business.JsonHelpers;
using Newtonsoft.Json;

namespace CoolStuff.FedEx.Models;

public class Token
{
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("token_type")]
    public string TokenType { get; set; }

    [JsonProperty("expires_in")]
    public long ExpiresIn { get; set; }

    [JsonProperty("scope")]
    public string Scope { get; set; }
    public DateTime ExpiresAt { get; set; }

    public static Token? FromJson(string json)
    {
        var deserializeObject = JsonConvert.DeserializeObject<Token>(json, JsonSettings.Settings);
        if (deserializeObject != null) deserializeObject.ExpiresAt = DateTime.UtcNow.AddMilliseconds(deserializeObject.ExpiresIn);
        return deserializeObject;
    }

    
}

