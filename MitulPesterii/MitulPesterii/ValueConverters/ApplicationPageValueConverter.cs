using MitulPesterii.Pages;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;

namespace MitulPesterii
{
    class ApplicationPageValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch((ApplicationPage)value)
            {
                case ApplicationPage.Start:
                    return new StartPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
