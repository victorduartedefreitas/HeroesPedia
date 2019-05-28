using HeroesPedia.Domain.Models;
using HeroesPedia.Domain.Views;

namespace HeroesPedia.Domain.ViewModels
{
    public interface IHeroDetailsViewModel : IBaseViewModel<IHeroDetailsView>
    {
        Hero Hero { get; set; }
    }
}
