using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace KonigLabs.CocaColaEvent.Entities.Classes
{
    [XmlInclude(typeof(TshortType))]
    public class TshortImage
    {
        public int Id { set; get; }
        public string ImageSrc { set; get; }
        
        private BitmapImage _image;
        public BitmapImage Image
        {
            get
            {
                return _image ?? (_image = new BitmapImage(new Uri(ImageSrc, UriKind.Absolute)));
            }
        }
    }
}
