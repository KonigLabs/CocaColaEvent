using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Navigation;
using KonigLabs.CocaColaEvent.Entities;
using KonigLabs.CocaColaEvent.Entities.Classes;
using KonigLabs.CocaColaEvent.ViewModel.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.CocaColaEvent.ViewModel.ViewModels
{
    public class SelectTypeViewModel : BaseNavigationViewModel
    {
        private TshortDto _tshort;

        public List<TshortType> TshortTypes { set; get; }
       
        public TshortType SelectedTshortType
        {
            set
            {
                _tshort.Type = value;
                RaisePropertyChanged();
            }
            get { return _tshort.Type; }
        }
        
        public TshortSize SelectedTshortSize
        {
            set
            {
                _tshort.Size = value;
                RaisePropertyChanged();
            }
            get
            {
                return _tshort.Size;
            }
        }
            
        public SelectTypeViewModel(IViewModelNavigator navigator, ElementProvider provider) : base(navigator)
        {
            _tshort = new TshortDto();
            TshortTypes = provider.GetTypes();
            SelectedTshortType = TshortTypes.FirstOrDefault();
        }
        protected override void OnNext()
        {
            _navigator.NavigateForward<SelectSizeViewModel>(this, _tshort);
        }
    }
}
