using System.Collections.Generic;

namespace HeroesPedia.Domain.Models
{
    public class HeroSearchResult
    {
        public string Response { get; set; }
        public string ResultsFor { get; set; }
        public List<Hero> Results { get; set; }
    }
}
