using System;

namespace WPFTest.Converters
{
    class BttnStyleConverter : StyleConverter
    {
        static StyleConverter converter;
        public BttnStyleConverter()
        {
            DarkStyleName = "DarkBttn";
            LightStyleName = "LightBttn";
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new BttnStyleConverter());

        }
    }
}
