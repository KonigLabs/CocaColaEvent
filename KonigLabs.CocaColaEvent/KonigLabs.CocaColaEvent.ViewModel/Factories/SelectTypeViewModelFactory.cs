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
    public class SelectTypeViewModelFactory : ViewModelBaseFactory<SelectTypeViewModel>
    {
        private IViewModelNavigator _navigator;
        private ElementProvider _provider;

        public SelectTypeViewModelFactory(IViewModelNavigator navigator, ElementProvider provider)
        {
            _navigator = navigator;
            _provider = provider;
        }
        protected override SelectTypeViewModel GetViewModel(object param)
        {
            return new SelectTypeViewModel(_navigator, _provider);
        }
    }
    
}
