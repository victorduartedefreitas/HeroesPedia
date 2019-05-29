using AutoMapper;
using HeroesPedia.SuperHeroAdapter;
using Prism;
using Prism.Ioc;
using System;

namespace HeroesPedia.Droid
{
    public class AndroidInitializer : IPlatformInitializer
    {
        public AndroidInitializer()
        {
            InitAutoMapper();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.AddHeroesPediaAdapters(new SuperHeroApiConfiguration { AccessToken = "2506483546063228" });
        }

        public void InitAutoMapper()
        {
            try
            {
                Mapper.AssertConfigurationIsValid();
            }
            catch(InvalidOperationException)
            {
                Mapper.Initialize(config =>
                {
                    config.AddProfile<SuperHeroMapperProfile>();
                });
            }
        }
    }
}