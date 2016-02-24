using GalaSoft.MvvmLight.Command;
using KonigLabs.CocaColaEvent.CommonViewModels.Messenger;
using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Navigation;
using KonigLabs.CocaColaEvent.Entities;
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
    public class ResultViewModel : BaseNavigationViewModel
    {
        private RelayCommand _completed;
        public RelayCommand Completed {
            get { return _completed ?? (_completed = new RelayCommand(OnCompleted)); }
        }
        public Visibility PositionTop { set; get; }
        public Visibility PositionCenter { set; get; }
        public Visibility PositionBottom { set; get; }
        public ImageSource SelectedLogo
        {
            get { return null; }
        }
        public string SelectedSize
        {
            get { return _tshort.Size.Name; }
        }

        public ImageSource SelectedDesign
        {
            get { return _tshort.Design.Image; }
        }
        public ImageSource SelectedType
        {
            get { return _tshort.Type.Image; }
        }
        public string SelectedText
        {
            get { return _tshort.Text.Text; }
        }
        public Thickness MarginText
        {
            get
            {
                return _tshort.Design.Id == 1 ? new Thickness(100, 180, 0, 0) : new Thickness(-100, -460, 0, 0);
            }
        }
        public int NumberPrint
        {
            set
            {
                _tshort.Id = value;
                RaisePropertyChanged();
            }
            get { return _tshort.Id; }
        }

        private TshortDto _tshort;
        private ElementProvider _provider;
        private IMessenger _messenger;
        public ResultViewModel(IViewModelNavigator navigator, TshortDto tshort, ElementProvider provider, IMessenger messenger) : base(navigator)
        {
            _tshort = tshort;
            _provider = provider;
            _messenger = messenger;
            NumberPrint = provider.GetNextNumberPrint();
        }

        private void OnCompleted()
        {
            if (!_provider.SavePrint(_tshort))
            {
                MessageBox.Show("Ошибка сохранения! Попробуйте позже");
            }
            _messenger.Send(_messenger.CreateMessage<CompletedMessage>());
        }

    }
}
