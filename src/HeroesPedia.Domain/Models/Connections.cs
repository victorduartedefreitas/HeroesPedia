using Newtonsoft.Json;

namespace HeroesPedia.Domain.Models
{
    public class Connections
    {
        [JsonProperty("group_affiliation")]
        public string GroupAffiliation { get; set; }
        public string Relatives { get; set; }
    }
}
