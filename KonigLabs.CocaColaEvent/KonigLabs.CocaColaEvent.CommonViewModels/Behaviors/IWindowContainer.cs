using System;

namespace KonigLabs.CocaColaEvent.CommonViewModels.Behaviors
{
    public interface IWindowContainer
    {
        event EventHandler<ShowWindowEventArgs> ShowWindow; 
    }
}
