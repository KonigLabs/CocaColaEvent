using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Navigation;
using KonigLabs.CocaColaEvent.Entities;
using KonigLabs.CocaColaEvent.Entities.Classes;
using KonigLabs.CocaColaEvent.ViewModel.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public Thickness MarginTshort
        {
            get
            {
                return _tshort.Type.Id == 1 ? new Thickness(148, 587, 0, 0) : new Thickness(185, 587, 0, 0);
            }
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
