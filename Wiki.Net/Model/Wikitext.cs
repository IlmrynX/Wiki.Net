using Newtonsoft.Json;

namespace Wiki.Net.Model
{
    public class Text
    {
        [JsonProperty("*")]
        public string Value { get; set; }
    }
}