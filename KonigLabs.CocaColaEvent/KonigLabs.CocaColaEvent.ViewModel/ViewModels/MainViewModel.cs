
using KonigLabs.CocaColaEvent.CommonViewModels.Behaviors;
using KonigLabs.CocaColaEvent.CommonViewModels.Messenger;
using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels;
using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Navigation;
using KonigLabs.CocaColaEvent.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.CocaColaEvent.ViewModel.ViewModels
{
    public class MainViewModel : BaseViewModel, IWindowContainer
    {
        private IViewModelNavigator _navigator;
        private IMessenger _messenger;
        public MainViewModel(IViewModelNavigator navigator, IMessenger messenger)
        {
            messenger.Register<ContentChangedMessage>(this, OnContentChanged);
            messenger.Register<CompletedMessage>(this,OnCompletedMessage);
            _messenger = messenger;
            _navigator = navigator;
            _navigator.NavigateForward<WelcomViewModel>(null);
        }
        private BaseViewModel _currentContent;

        public event EventHandler<ShowWindowEventArgs> ShowWindow;

        public BaseViewModel CurrentContent
        {
            get { return _currentContent; }
            set
            {
                _currentContent = value;
                RaisePropertyChanged();
            }
        }

        private void OnCompletedMessage(CompletedMessage message)
        {
            _navigator.NavigateForward<WelcomViewModel>(new TshortDto());
        }

        private void OnContentChanged(ContentChangedMessage message)
        {
            if (CurrentContent != null)
                CurrentContent.Dispose();

            CurrentContent = message.Content;
            if (CurrentContent != null)
                CurrentContent.Initialize();
        }
    }
}
