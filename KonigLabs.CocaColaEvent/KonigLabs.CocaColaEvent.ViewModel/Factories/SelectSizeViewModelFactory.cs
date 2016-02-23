using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Factories;
using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Navigation;
using KonigLabs.CocaColaEvent.Entities;
using KonigLabs.CocaColaEvent.ViewModel.Providers;
using KonigLabs.CocaColaEvent.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.CocaColaEvent.ViewModel.Factories
{
    public class SelectSizeViewModelFactory : ViewModelBaseFactory<SelectSizeViewModel>
    {
        private IViewModelNavigator _navigator;
        public SelectSizeViewModelFactory(IViewModelNavigator navigator)
        {
            _navigator = navigator;
        }
        protected override SelectSizeViewModel GetViewModel(object param)
        {
            return new SelectSizeViewModel(_navigator, (TshortDto)param);
        }

    }
}
