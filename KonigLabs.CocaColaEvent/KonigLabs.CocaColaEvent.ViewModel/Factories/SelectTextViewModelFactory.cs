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
    public  class SelectTextViewModelFactory : ViewModelBaseFactory<SelectTextViewModel>
    {
        private IViewModelNavigator _navigator;
        private ElementProvider _elementProvider;
        public SelectTextViewModelFactory(IViewModelNavigator navigator, ElementProvider elementProvider)
        {
            _navigator = navigator;
            _elementProvider = elementProvider;
        }
        protected override SelectTextViewModel GetViewModel(object param)
        {
            return new SelectTextViewModel(_navigator, (TshortDto)param, _elementProvider);
        }
    }
}
