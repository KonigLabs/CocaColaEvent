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
    class SelectDesignViewModelFactory : ViewModelBaseFactory<SelectDesignViewModel>
    {
        private IViewModelNavigator _navigator;
        private ElementProvider _elementProvider;
        public SelectDesignViewModelFactory(IViewModelNavigator navigator, ElementProvider elementProvider)
        {
            _navigator = navigator;
            _elementProvider = elementProvider;
        }
        protected override SelectDesignViewModel GetViewModel(object param)
        {
            return new SelectDesignViewModel(_navigator, (TshortDto)param, _elementProvider);
        }
    }
    
}
