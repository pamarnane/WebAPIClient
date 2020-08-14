using System;
using System.Text.Json.Serialization;

namespace WebAPIClient
{
    public class Repository
    {
        [JsonPropertyName("Ch")]
        public int Ch { get; set; }

        [JsonPropertyName("Val")]
        public int Val { get; set; }
        // public string email { get; set; }
        //  public string state { get; set; }
    }
}