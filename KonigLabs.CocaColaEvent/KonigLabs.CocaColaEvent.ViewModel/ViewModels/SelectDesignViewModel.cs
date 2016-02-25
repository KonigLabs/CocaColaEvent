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
    public class SelectDesignViewModel : BaseNavigationViewModel
    {
        private TshortDto _tshort;

        public List<TshortImage> Designs { set; get; }
        public ImageSource SelectedType { get { return _tshort.Type.Image; } }
        public TshortImage SelectedDesign { set { _tshort.Design = value; RaisePropertyChanged(); } get { return _tshort.Design; } }
        public Thickness MarginTshort
        {
            get
            {
                return _tshort.Type.Id == 1 ? new Thickness(148, 587, 0, 0) : new Thickness(185, 587, 0, 0);
            }
        }
        public SelectDesignViewModel(IViewModelNavigator navigator, TshortDto tshort, ElementProvider elementProvider) : base(navigator)
        {
            _tshort = tshort;
            Designs = elementProvider.GetDesigns();
            SelectedDesign = Designs.FirstOrDefault();
        }
        
        protected override void OnNext()
        {
            _navigator.NavigateForward<SelectTextViewModel>(this, _tshort);
        }
    }
}
