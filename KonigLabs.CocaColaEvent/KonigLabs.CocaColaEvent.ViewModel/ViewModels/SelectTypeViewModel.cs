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

        private bool _womenTshortExists;
        public bool WomenTshortExists
        {
            get { return _womenTshortExists; }
            set
            {
                _womenTshortExists = value;
                RaisePropertyChanged();
            }
        }

        private bool _menTshortExists;
        public bool MenTshortExists
        {
            get { return _menTshortExists; }
            set
            {
                _menTshortExists = value;
                RaisePropertyChanged();
            }
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
            MenTshortExists = TshortTypes.Any(x => x.Label.ToLower() == "мужская");
            WomenTshortExists = TshortTypes.Any(x => x.Label.ToLower() == "женская");
            SelectedTshortType = TshortTypes.FirstOrDefault();
        }
        protected override void OnNext()
        {
            if (!TshortTypes.Any())
            {
                MessageBox.Show("В настоящее время футболки закончились. Извините!", "Coca Cola", MessageBoxButton.OK);
                return;
            }
            _navigator.NavigateForward<SelectSizeViewModel>(this, _tshort);
        }
    }
}
