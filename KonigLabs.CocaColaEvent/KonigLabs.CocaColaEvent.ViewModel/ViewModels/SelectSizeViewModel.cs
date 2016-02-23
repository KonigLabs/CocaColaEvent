using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Navigation;
using KonigLabs.CocaColaEvent.Entities;
using KonigLabs.CocaColaEvent.Entities.Classes;
using KonigLabs.CocaColaEvent.ViewModel.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace KonigLabs.CocaColaEvent.ViewModel.ViewModels
{
    public class SelectSizeViewModel : BaseNavigationViewModel
    {
        private TshortDto _tshort;
        public TshortSize SelectedSize
        {
            set
            {
                _tshort.Size = value;
                RaisePropertyChanged();
            }
            get { return _tshort.Size; }
        }
        public TshortType SelectedType
        {
            get { return _tshort.Type; }
        }
        public SelectSizeViewModel(IViewModelNavigator navigator, TshortDto tshort) : base(navigator)
        {
            _tshort = tshort;
            SelectedSize = _tshort.Type.Size.FirstOrDefault();
        }
        protected override void OnNext()
        {
            _navigator.NavigateForward<SelectDesignViewModel>(this,_tshort);
        }
    }
}
