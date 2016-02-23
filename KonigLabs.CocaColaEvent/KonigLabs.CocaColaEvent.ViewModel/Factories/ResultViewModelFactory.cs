using KonigLabs.CocaColaEvent.CommonViewModels.Messenger;
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
    public class ResultViewModelFactory : ViewModelBaseFactory<ResultViewModel>
    {
        private IViewModelNavigator _navigator;
        private ElementProvider _provider;
        private IMessenger _messenger;
        public ResultViewModelFactory(IViewModelNavigator navigator, ElementProvider provider, IMessenger messenger)
        {
            _navigator = navigator;
            _provider = provider;
            _messenger = messenger;
        }
        protected override ResultViewModel GetViewModel(object param)
        {
            return new ResultViewModel(_navigator, (TshortDto)param, _provider, _messenger);
        }
    }
}
