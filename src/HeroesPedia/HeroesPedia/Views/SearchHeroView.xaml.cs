using HeroesPedia.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HeroesPedia.Application.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchHeroView : ContentPage, ISearchHeroView
    {
        public SearchHeroView()
        {
            InitializeComponent();
        }
    }
}