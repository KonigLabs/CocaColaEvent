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
using System.Windows;

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
           var tshortTypes = _provider.GetTypes();
            if (!tshortTypes.Any())
            {
                MessageBox.Show("В настоящее время футболки закончились. Извините!", "Coca Cola", MessageBoxButton.OK,MessageBoxImage.Information);
                return null;
            }
            return new SelectTypeViewModel(_navigator, _provider);
        }
    }
    
}
