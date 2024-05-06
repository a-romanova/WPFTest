using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Xaml;
using WPFTest;

namespace WPFTest.Converters
{
    internal class StyleConverter : MarkupExtension, IValueConverter
    {
        static StyleConverter converter;
        
        static ResourceDictionary lightResourceDict;
        static ResourceDictionary DarkResourceDict;

        protected string DarkStyleName;
        protected string LightStyleName;

        static StyleConverter()
        {
            lightResourceDict = new ResourceDictionary();
            lightResourceDict.Source = new Uri("pack://application:,,,/TestStylesLib;component/lightstyle.xaml", UriKind.RelativeOrAbsolute);
            //lightResourceDict.Source = new Uri("WPFTest;component/lightstyle.xaml", UriKind.RelativeOrAbsolute);
          

            DarkResourceDict = new ResourceDictionary();
            //DarkResourceDict.Source = new Uri("WPFTest;component/darkstyle.xaml", UriKind.RelativeOrAbsolute);
            DarkResourceDict.Source = new Uri("pack://application:,,,/TestStylesLib;component/darkstyle.xaml", UriKind.RelativeOrAbsolute);
          
        }

        public StyleConverter()
        {
            DarkStyleName = "Dark";
            LightStyleName = "Light";
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var styleType = (StyleType)value;
            if (styleType == StyleType.Dark)
                return DarkResourceDict[DarkStyleName] as Style; 
            else
                return lightResourceDict[LightStyleName] as Style; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new StyleConverter());

        }
    }
}
