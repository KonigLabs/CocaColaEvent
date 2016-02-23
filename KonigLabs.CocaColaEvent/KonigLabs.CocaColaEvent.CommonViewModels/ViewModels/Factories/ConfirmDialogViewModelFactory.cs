using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Dialogs;

namespace KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Factories
{
    public class ConfirmDialogViewModelFactory : ViewModelBaseFactory<ConfirmDialogViewModel>
    {
        protected override ConfirmDialogViewModel GetViewModel(object param)
        {
            return new ConfirmDialogViewModel(param.ToString());
        }
    }
}