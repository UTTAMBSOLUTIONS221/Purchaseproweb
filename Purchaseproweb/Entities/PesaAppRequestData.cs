using Newtonsoft.Json;

namespace Purchaseproweb.Entities
{
    public class PesaAppRequestData
    {
        [JsonProperty("timestamp")]
        public string? TimeStamp { get; set; }

        [JsonProperty("servicecode")]
        public int ServiceCode { get; set; }

        [JsonProperty("accountnumber")]
        public string? AccountNumber { get; set; }

        [JsonProperty("data")]
        public PesaAppRequestBody Data { get; set; }
    }

}
