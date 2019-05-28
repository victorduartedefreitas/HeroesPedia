using HeroesPedia.Domain.Views;
using System.Collections.Generic;

namespace HeroesPedia.Domain.ViewModels
{
    public interface IBaseViewModel<TView> : IBaseViewModel
        where TView : IBaseView
    {
        TView CurrentView { get; }
    }
    public interface IBaseViewModel
    {
        bool IsBusy { get; set; }
        bool HasChanged { get; }
        IReadOnlyCollection<string> ChangedProperties { get; }
    }
}
