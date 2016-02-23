using GalaSoft.MvvmLight.CommandWpf;

namespace KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Dialogs
{
    public class InfoDialogViewModel : DialogBase
    {
        private RelayCommand _closeCommand;

        public InfoDialogViewModel(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }

        public override string Title
        {
            get { return "Информация"; }
        }

        public RelayCommand CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new RelayCommand(Close)); }
        }
    }
}