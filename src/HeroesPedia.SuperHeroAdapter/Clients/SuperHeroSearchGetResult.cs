using HeroesPedia.Domain.Models;
using System.Collections.Generic;

namespace HeroesPedia.SuperHeroAdapter.Clients
{
    internal class SuperHeroSearchGetResult
    {
        public string Response { get; set; }
        public string ResultsFor { get; set; }
        public List<Hero> Results { get; set; }
    }
}
