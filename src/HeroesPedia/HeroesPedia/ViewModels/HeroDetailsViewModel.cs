using HeroesPedia.Domain.Models;
using HeroesPedia.Domain.ViewModels;
using HeroesPedia.Domain.Views;
using Prism.Navigation;
using Prism.Services;

namespace HeroesPedia.Application.ViewModels
{
    public class HeroDetailsViewModel : BaseViewModel<IHeroDetailsView>, IHeroDetailsViewModel
    {
        #region Constructors

        public HeroDetailsViewModel(INavigationService navigationService,
            IPageDialogService pageDialogService,
            IHeroDetailsView view)
            : base(navigationService, pageDialogService, view)
        {
        }

        #endregion

        #region Fields

        private Hero hero;

        #endregion

        #region Properties

        public Hero Hero
        {
            get => hero;
            set { SetProperty(ref hero, value); }
        }

        #endregion

        #region Public Methods

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var pHero = parameters["Hero"];
            if (pHero != null && pHero is Hero)
                Hero = (Hero)pHero;
        }

        #endregion
    }
}
