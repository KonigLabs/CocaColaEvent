using KonigLabs.CocaColaEvent.Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace KonigLabs.CocaColaEvent.Entities
{
    public class TshortDto
    {
        public int Id { set; get; }
        public TshortSize Size { set; get; }
        public TshortType Type { set; get; }
        public TshortImage Design { set; get; }
        public string Text { set; get; }
    }
}
