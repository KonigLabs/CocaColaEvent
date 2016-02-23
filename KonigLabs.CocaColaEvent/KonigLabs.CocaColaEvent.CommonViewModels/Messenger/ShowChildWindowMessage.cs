using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels;

namespace KonigLabs.CocaColaEvent.CommonViewModels.Messenger
{
    public class ShowChildWindowMessage
    {
        public bool IsDialog { get; set; }

        public BaseViewModel Content { get; set; }
    }
}
