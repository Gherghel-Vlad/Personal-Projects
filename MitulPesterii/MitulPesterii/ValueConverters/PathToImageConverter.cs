using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MitulPesterii
{
    class PathToImageConverter
    {
        public static Image PathToImage(string path)
        {
            Uri imageUri = new Uri(path, UriKind.Relative);
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            Image myImage = new Image();
            myImage.Source = imageBitmap;
            return myImage;
        }
    }
}
