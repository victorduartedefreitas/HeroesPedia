using HeroesPedia.Domain.Adapters;
using HeroesPedia.SuperHeroAdapter;
using HeroesPedia.SuperHeroAdapter.Clients;
using Refit;
using System;
using System.Net.Http;

namespace Prism.Ioc
{
    public static class SuperHeroAdapterContainerRegistryExtensions
    {
        public static IContainerRegistry AddHeroesPediaAdapters(this IContainerRegistry containerRegistry, SuperHeroApiConfiguration superHeroApiConfiguration)
        {
            containerRegistry.Register<ISuperHeroApiAdapter, SuperHeroApiAdapter>();
            containerRegistry.RegisterInstance(superHeroApiConfiguration);
            containerRegistry.RegisterInstance(CreateSuperHeroApiInstance(superHeroApiConfiguration));
            return containerRegistry;
        }

        private static ISuperHeroApi CreateSuperHeroApiInstance(SuperHeroApiConfiguration superHeroApiConfiguration)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(string.Format("https://superheroapi.com/api/{0}/", superHeroApiConfiguration.AccessToken));

            return RestService.For<ISuperHeroApi>(httpClient);
        }
    }
}
