using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Dialogs;

namespace KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Factories
{
    public class InfoDialogViewModelFactory : ViewModelBaseFactory<InfoDialogViewModel>
    {
        protected override InfoDialogViewModel GetViewModel(object param)
        {
            return new InfoDialogViewModel(param.ToString());
        }
    }
}