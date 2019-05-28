using HeroesPedia.Application.ViewModels;
using HeroesPedia.Application.Views;
using HeroesPedia.Domain.ViewModels;
using HeroesPedia.Domain.Views;

namespace Prism.Ioc
{
    public static class ApplicationContainerRegistryExtensions
    {
        public static IContainerRegistry AddHeroesPediaViewModels(this IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ISearchHeroView, SearchHeroView>();
            containerRegistry.Register<ISearchHeroViewModel, SearchHeroViewModel>();
            containerRegistry.Register<IHeroDetailsView, HeroDetailsView>();
            containerRegistry.Register<IHeroDetailsViewModel, HeroDetailsViewModel>();

            containerRegistry.RegisterForNavigation<SearchHeroView, SearchHeroViewModel>();
            containerRegistry.RegisterForNavigation<HeroDetailsView, HeroDetailsViewModel>();

            return containerRegistry;
        }
    }
}
