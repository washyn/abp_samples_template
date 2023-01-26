using System;
using System.Text.Json.Serialization;

namespace EasyAbp.LoggingManagement.SystemLogs.Dtos
{
    public class SystemLogDto
    {
        public string LogName { get; set; }
        
        public string LogValue { get; set; }
        
        public DateTime? Time { get; set; }
        
        public string Level { get; set; }
    }
    
    
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class ExtraProperties
    {
    }

    public class Item
    {
        [JsonPropertyName("tenantId")]
        public object TenantId;

        [JsonPropertyName("applicationName")]
        public string ApplicationName;

        [JsonPropertyName("identity")]
        public string Identity;

        [JsonPropertyName("action")]
        public string Action;

        [JsonPropertyName("userId")]
        public string UserId;

        [JsonPropertyName("userName")]
        public string UserName;

        [JsonPropertyName("tenantName")]
        public object TenantName;

        [JsonPropertyName("clientId")]
        public object ClientId;

        [JsonPropertyName("correlationId")]
        public string CorrelationId;

        [JsonPropertyName("clientIpAddress")]
        public string ClientIpAddress;

        [JsonPropertyName("browserInfo")]
        public string BrowserInfo;

        [JsonPropertyName("creationTime")]
        public DateTime? CreationTime;

        [JsonPropertyName("extraProperties")]
        public ExtraProperties ExtraProperties;

        [JsonPropertyName("id")]
        public string Id;
    }

    public class Root
    {
        [JsonPropertyName("totalCount")]
        public int? TotalCount;

        [JsonPropertyName("items")]
        public List<Item> Items;
    }
}