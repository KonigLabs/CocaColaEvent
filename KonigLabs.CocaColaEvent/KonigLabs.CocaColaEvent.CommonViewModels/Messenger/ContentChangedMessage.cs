using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels;

namespace KonigLabs.CocaColaEvent.CommonViewModels.Messenger
{
    public class ContentChangedMessage
    {
        public ContentChangedMessage()
        {
        }

        public object Parameter { get; set; }

        public BaseViewModel Content { get; set; }
    }
}
