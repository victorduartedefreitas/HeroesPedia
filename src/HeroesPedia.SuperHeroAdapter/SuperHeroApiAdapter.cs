using AutoMapper;
using HeroesPedia.Domain.Adapters;
using HeroesPedia.Domain.Models;
using HeroesPedia.SuperHeroAdapter.Clients;
using System;
using System.Threading.Tasks;

namespace HeroesPedia.SuperHeroAdapter
{
    internal class SuperHeroApiAdapter : ISuperHeroApiAdapter
    {
        #region Fields

        private readonly ISuperHeroApi superHeroApi;

        #endregion

        #region Constructors

        public SuperHeroApiAdapter(ISuperHeroApi superHeroApi)
        {
            this.superHeroApi = superHeroApi ?? throw new ArgumentNullException(nameof(superHeroApi));
        }

        #endregion

        #region Public Methods

        public async Task<HeroSearchResult> SearchHeroAsync(string heroName)
        {
            var result = await superHeroApi.SearchHero(heroName);
            return Mapper.Map<HeroSearchResult>(result);
        }

        #endregion
    }
}
