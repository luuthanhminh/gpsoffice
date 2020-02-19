using System;
using Newtonsoft.Json;

namespace gpsoffice.Core.Data.Models
{
    public class Voucher
    {
        [JsonProperty("autoid")]
        public int Autoid { get; set; }

        [JsonProperty("voucherNumber")]
        public string VoucherNumber { get; set; }

        [JsonProperty("voucherDate")]
        public string VoucherDate { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("narration")]
        public string Narration { get; set; }
    }
}
