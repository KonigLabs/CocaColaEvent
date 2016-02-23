using System;
using KonigLabs.CocaColaEvent.CommonViewModels.Behaviors;

namespace KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Dialogs
{
    public abstract class DialogBase : BaseViewModel, ICloseable
    {
        public event EventHandler<bool> StateChanged;
        public event Action<WindowState> RequestWindowVisibilityChanged;
        public void OnClose()
        {
            
        }

        protected void Close()
        {
            var handler = RequestWindowVisibilityChanged;
            if (handler != null)
                handler(WindowState.Closed);
        }

        public abstract string Title { get; }
    }
}