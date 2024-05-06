using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace WPFTest
{
    public static class FocusProperties
    {
        public static readonly DependencyProperty FocusForegroundColorProperty =
            DependencyProperty.RegisterAttached("FocusForegroundColor", typeof(Brush), typeof(FocusProperties), new PropertyMetadata(Brushes.Transparent, OnFocusForegroundColorChanged));

        public static void SetFocusForegroundColor(DependencyObject element, Brush value)
        {
            element.SetValue(FocusForegroundColorProperty, value);
        }

        public static Brush GetFocusForegroundColor(DependencyObject element)
        {
            return (Brush)element.GetValue(FocusForegroundColorProperty);
        }

        private static void OnFocusForegroundColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            if (d is TextBox textBox)
            {
                textBox.GotFocus += (s, e) => { textBox.Foreground = (Brush)args.NewValue; };
                textBox.LostFocus += (s, e) => textBox.Foreground = Brushes.Black;
            }
        }
    }
}
