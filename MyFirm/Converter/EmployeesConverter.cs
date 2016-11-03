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
    //Show Employees in TasksDateGrid 
    [ValueConversion(typeof(ICollection<Tasks>), typeof(string))]
    public class EmployeesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Tasks.ReturnEmployeeNameAndSurName(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
