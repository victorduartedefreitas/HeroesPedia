using Prism;
using Prism.Autofac;
using Prism.Ioc;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HeroesPedia.Application
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer = null)
            : base(platformInitializer)
        {
            //MainPage = new MainPage();
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.AddHeroesPediaViewModels();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }        
    }
}
