using HeroesPedia.Domain.ViewModels;
using HeroesPedia.Domain.Views;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HeroesPedia.Application.ViewModels
{
    public abstract class BaseViewModel<TView> : BaseViewModel, IBaseViewModel<TView>
        where TView : IBaseView
    {
        #region Constructors

        public BaseViewModel(INavigationService navigationService,
            IPageDialogService pageDialogService,
            TView view)
            : base(navigationService, pageDialogService)
        {
            CurrentView = view;
        }

        #endregion

        #region Fields

        private TView _currentView;

        #endregion

        #region Properties

        public TView CurrentView
        {
            get => _currentView;
            protected set => _currentView = value;
        }

        #endregion
    }

    public abstract class BaseViewModel : IBaseViewModel, INotifyPropertyChanged, INavigatedAware
    {
        #region Constructors

        public BaseViewModel(INavigationService navigationService,
            IPageDialogService pageDialogService)
        {
            this.navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            this.pageDialogService = pageDialogService ?? throw new ArgumentNullException(nameof(pageDialogService));
        }

        #endregion

        #region Fields

        private bool _isBusy;
        private List<string> _changedProperties = new List<string>();
        private readonly INavigationService navigationService;
        private readonly IPageDialogService pageDialogService;

        #endregion

        #region Properties & Events

        protected INavigationService NavigationService { get => navigationService; }
        protected IPageDialogService PageDialogService { get => pageDialogService; }

        public bool IsBusy
        {
            get => _isBusy;
            set { SetProperty(ref _isBusy, value); }
        }

        public IReadOnlyCollection<string> ChangedProperties
        {
            get => _changedProperties;
        }

        public bool HasChanged => ChangedProperties.Count > 0;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Methods

        public bool SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (!_changedProperties.Contains(propertyName))
                _changedProperties.Add(propertyName);

            return true;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        #endregion
    }
}
