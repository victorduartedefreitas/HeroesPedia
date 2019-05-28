using Refit;
using System.Threading.Tasks;

namespace HeroesPedia.SuperHeroAdapter.Clients
{
    internal interface ISuperHeroApi
    {
        [Get("/search/{name}")]
        Task<SuperHeroSearchGetResult> SearchHero([AliasAs("name")] string heroName);
    }
}
