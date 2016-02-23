using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Factories;
using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Navigation;
using KonigLabs.CocaColaEvent.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.CocaColaEvent.ViewModel.Factories
{
    public class WelcomViewModelFactory : ViewModelBaseFactory<WelcomViewModel>
    {
        private IViewModelNavigator _navigator;
        public WelcomViewModelFactory(IViewModelNavigator navigator)
        {
            _navigator = navigator;
        }
        protected override WelcomViewModel GetViewModel(object param)
        {
            return new WelcomViewModel(_navigator);
        }
    }
}
