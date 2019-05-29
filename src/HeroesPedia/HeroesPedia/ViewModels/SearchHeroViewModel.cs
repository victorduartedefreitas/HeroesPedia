using HeroesPedia.Domain.Adapters;
using HeroesPedia.Domain.Models;
using HeroesPedia.Domain.ViewModels;
using HeroesPedia.Domain.Views;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HeroesPedia.Application.ViewModels
{
    public class SearchHeroViewModel : BaseViewModel<ISearchHeroView>, ISearchHeroViewModel
    {
        #region Constructors

        public SearchHeroViewModel(INavigationService navigationService,
            IPageDialogService pageDialogService,
            ISearchHeroView view,
            ISuperHeroApiAdapter superHeroApiAdapter)
            : base(navigationService, pageDialogService, view)
        {
            this.superHeroApiAdapter = superHeroApiAdapter ?? throw new ArgumentNullException(nameof(superHeroApiAdapter));
        }

        #endregion

        #region Fields

        private readonly ISuperHeroApiAdapter superHeroApiAdapter;
        private ICommand searchCommand;
        private ICommand moreInfoCommand;
        private string searchText;
        private ObservableCollection<Hero> heroes;

        #endregion

        #region Properties

        public ICommand SearchCommand
        {
            get
            {
                if (searchCommand == null)
                    searchCommand = new DelegateCommand(async () => await SearchHero(), CanSearchHero);

                return searchCommand;
            }
        }

        public ICommand MoreInfoCommand
        {
            get
            {
                if (moreInfoCommand == null)
                    moreInfoCommand = new DelegateCommand<string>(MoreInfo, CanMoreInfo);

                return moreInfoCommand;
            }
        }

        public string SearchText
        {
            get { return searchText; }
            set { SetProperty(ref searchText, value); }
        }

        public ObservableCollection<Hero> Heroes
        {
            get { return heroes; }
            private set { SetProperty(ref heroes, value); }
        }

        #endregion

        #region Public Methods

        public bool CanSearchHero()
        {
            return true;
        }

        public async Task SearchHero()
        {
            try
            {
                IsBusy = true;

                var result = await superHeroApiAdapter.SearchHeroAsync(SearchText);

                if (result.Results == null || result.Results.Count == 0)
                {
                    await DisplayAlertAsync("Não foi possível encontrar um herói com o tempo pesquisado.", "Pesquisa", "OK");
                    return;
                }

                Heroes = new ObservableCollection<Hero>(result.Results);
            }
            catch
            {
                await DisplayAlertAsync("Ocorreu um erro inesperado na pesquisa.", "Pesquisa", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public bool CanMoreInfo(string id)
        {
            return true;
        }

        public void MoreInfo(string id)
        {
            var hero = Heroes.FirstOrDefault(f => f.Id == id);

            if (hero == null)
                return;

            var parameters = new NavigationParameters();
            parameters.Add("Hero", hero);
            NavigateAsync("HeroDetailsView", parameters);
        }

        #endregion
    }
}
