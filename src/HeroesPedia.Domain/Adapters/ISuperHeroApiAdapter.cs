using HeroesPedia.Domain.Models;
using System.Threading.Tasks;

namespace HeroesPedia.Domain.Adapters
{
    public interface ISuperHeroApiAdapter
    {
        Task<HeroSearchResult> SearchHeroAsync(string heroName);
    }
}
