using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace AppWindowsWPF.Converter
{
    /// <summary>
    /// permet de convertir une image
    /// </summary>
    public class ImageSourceConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string imageName = value as string;
            string valeurParDéfaut = parameter as string;
            if (string.IsNullOrWhiteSpace(imageName))
            {
                imageName = valeurParDéfaut;
            }

            BitmapImage image = new BitmapImage(new Uri(
                    string.Format("images/{0}", imageName),
                    UriKind.Relative));

            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
