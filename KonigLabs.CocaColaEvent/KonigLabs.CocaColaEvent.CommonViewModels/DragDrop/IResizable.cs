using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.CocaColaEvent.CommonViewModels.DragDrop
{
    public interface IResizable
    {
        void Resize(double deltaX, double deltaY, double offsetX, double offsetY);
    }
}
