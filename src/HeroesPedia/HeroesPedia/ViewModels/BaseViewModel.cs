using HeroesPedia.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace HeroesPedia.Application.ViewModels
{
    public abstract class BaseViewModel : IBaseViewModel, INotifyPropertyChanged
    {
        #region Fields

        private bool _isBusy;
        private List<string> _changedProperties = new List<string>();

        #endregion

        #region Properties & Events

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    SetProperty(ref _isBusy, value);
                }
            }
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

        #endregion
    }
}
