using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace WPFTest.Converters
{
    internal class CommentTypeToBrushConverter:MarkupExtension, IValueConverter
    {
        private static CommentTypeToBrushConverter converter;
        static Brush NumberColor = new SolidColorBrush(Colors.LightBlue);
        static Brush TextColor = new SolidColorBrush(Colors.White);
        static Brush EmptyColor =  new SolidColorBrush(Colors.LightGray);
      
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var commentType = (TypeOfComment)value;

            if (commentType == TypeOfComment.Empty)
                return EmptyColor;
           
            if (commentType == TypeOfComment.Number)
                return NumberColor;
            else
                return TextColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new CommentTypeToBrushConverter());
        }
    }
}
