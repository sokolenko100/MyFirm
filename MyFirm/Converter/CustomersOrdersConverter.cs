using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirm.Model;
using System.Windows.Data;
using System.Globalization;

namespace MyFirm.Converter
{

    //Show Customer in OredersDateGrid 
    [ValueConversion(typeof(ICollection<CustomersOrders>), typeof(string))]
    public class CustomersOrdersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return CustomersOrders.ReturnCustomersOrdersCollection(value);
    }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}