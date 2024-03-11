using Energy_Counter.Models;
using Energy_Counter.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Energy_Counter.Converters
{
    class ResourceToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var resource = value as Resource;
            if (resource.Name.ToLower().Contains("electr"))
            {
                return "D:\\Mein progectos\\Energy Counter\\Energy Counter\\Images\\Electricity.png";
            }
            else if (resource.Name.ToLower().Contains("water"))
            {
                return "D:\\Mein progectos\\Energy Counter\\Energy Counter\\Images\\Water.jpg";
            }
            else if (resource.Name.ToLower().Contains("gas"))
            {
                return "D:\\Mein progectos\\Energy Counter\\Energy Counter\\Images\\Gas.png";
            }
            return "D:\\Mein progectos\\Energy Counter\\Energy Counter\\Images\\NoImage.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
