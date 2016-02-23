using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonigLabs.CocaColaEvent.Entities.Classes
{
    public class TshortType : TshortImage
    {
        public List<TshortSize> Size { set; get; }
        public string Label { set; get; }
    }
}
