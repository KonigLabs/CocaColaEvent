using GalaSoft.MvvmLight.Command;
using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels;
using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.CocaColaEvent.ViewModel.ViewModels
{
    public abstract class BaseNavigationViewModel : BaseViewModel
    {
        protected IViewModelNavigator _navigator;
        public BaseNavigationViewModel(IViewModelNavigator navigator)
        {
            _navigator = navigator;
        }
        private RelayCommand _preview;
        
        public RelayCommand Preview
        {
            get
            {
                return _preview ?? (_preview = new RelayCommand(OnPreview));
            }
        }

        protected virtual void OnPreview()
        {
            _navigator.NavigateBack(this);
        }

        private RelayCommand _next;
        public RelayCommand Next
        {
            get
            {
                return _next ?? (_next = new RelayCommand(OnNext, OnEnableNext));
            }
        }
        protected virtual bool OnEnableNext()
        {
            return true;
        }
        protected virtual void OnNext()
        {
        }
    }
}
