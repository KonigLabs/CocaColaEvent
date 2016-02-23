using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Validation;

namespace KonigLabs.CocaColaEvent.CommonViewModels.ViewModels.Dialogs
{
    public abstract class ResultBaseViewModel : ValidateableViewModel
    {
        public abstract bool CanConfirm { get; }

        public abstract string Title { get; }
    }
}
