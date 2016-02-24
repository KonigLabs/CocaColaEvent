using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Navigation;
using KonigLabs.CocaColaEvent.Entities;
using KonigLabs.CocaColaEvent.Entities.Classes;
using KonigLabs.CocaColaEvent.ViewModel.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace KonigLabs.CocaColaEvent.ViewModel.ViewModels
{
    public class SelectTextViewModel : BaseNavigationViewModel
    {

        private TshortDto _tshort;
        
        public List<TshortString> Texts { set; get; }

        public ImageSource SelectedType
        {
            get { return _tshort.Type.Image; }
        }
        public Thickness MarginText
        {
            get
            {
                return _tshort.Design.Id == 1 ? new Thickness(100, 140, 0, 0) : new Thickness(-100, -500, 0, 0);
            }
        }
        public TshortString SelectedText
        {
            set
            {
                _tshort.Text = value;                
                RaisePropertyChanged();
                //todo грязный хак для того что бы выбор хотябы оставался, надо думать что делать с тем что бы ScrollViewer не откатывался
                Thread.Sleep(100);
            }
            get { return _tshort.Text; }
        }

        public ImageSource SelectedDesign
        {
            get { return _tshort.Design.Image; }
        }
        public SelectTextViewModel(IViewModelNavigator navigator, TshortDto tshort, ElementProvider elementProvider) : base(navigator)
        {
            _tshort = tshort;
            Texts = elementProvider.GetTexts();
            SelectedText = Texts.FirstOrDefault();
        }
        protected override void OnNext()
        {
            _navigator.NavigateForward<ResultViewModel>(this, _tshort);
        }
    }
}
