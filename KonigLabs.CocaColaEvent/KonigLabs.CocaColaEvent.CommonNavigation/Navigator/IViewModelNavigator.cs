using KonigLabs.SpriteEvent.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.SpriteEvent.ViewModel.Navigator
{
    public interface IViewModelNavigator
    {
        void NavigateBack(BaseViewModel viewModel);
        void NavigateForward(BaseViewModel from, BaseViewModel to);
        void NavigateForward(BaseViewModel to);

        void NavigateForward<TViewModelTo>(BaseViewModel from, object param) where TViewModelTo : BaseViewModel;
        void NavigateForward<TViewModelTo>(object param) where TViewModelTo : BaseViewModel;
    }
}
