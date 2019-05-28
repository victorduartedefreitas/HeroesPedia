using HeroesPedia.SuperHeroAdapter;
using Prism;
using Prism.Ioc;

namespace HeroesPedia.Droid
{
    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.AddHeroesPediaAdapters(new SuperHeroApiConfiguration { AccessToken = "2506483546063228" });
        }
    }
}