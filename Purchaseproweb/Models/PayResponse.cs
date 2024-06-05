using Newtonsoft.Json;

namespace Purchaseproweb.Models
{
    public class PayResponse
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public dynamic Data { get; set; }
    }
}
