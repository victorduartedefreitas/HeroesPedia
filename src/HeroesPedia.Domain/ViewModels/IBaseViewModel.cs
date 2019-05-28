using System.Collections.Generic;

namespace HeroesPedia.Domain.ViewModels
{
    public interface IBaseViewModel
    {
        bool IsBusy { get; set; }
        bool HasChanged { get; }
        IReadOnlyCollection<string> ChangedProperties { get; }
    }
}
