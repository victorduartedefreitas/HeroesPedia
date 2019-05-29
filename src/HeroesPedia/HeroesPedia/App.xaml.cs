using Prism;
using Prism.Autofac;
using Prism.Ioc;
using Prism.Navigation;

namespace HeroesPedia.Application
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer = null)
            : base(platformInitializer)
        {
        }

        public INavigationService GetNavigationService()
        {
            return NavigationService;
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("SearchHeroView");
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
