using AutoMapper;
using HeroesPedia.Domain.Models;
using HeroesPedia.SuperHeroAdapter.Clients;

namespace HeroesPedia.SuperHeroAdapter
{
    public class SuperHeroMapperProfile : Profile
    {
        public SuperHeroMapperProfile()
        {
            CreateMap<SuperHeroSearchGetResult, HeroSearchResult>();
        }
    }
}
