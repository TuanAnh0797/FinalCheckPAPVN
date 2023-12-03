using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FinalCheck.MyConverter
{
    public class PDConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Chuyển đổi giá trị từ nguồn dữ liệu sang giao diện người dùng
            if (value != null && value.ToString() == "PD")
            {
                return "Pending";
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Chuyển đổi giá trị từ giao diện người dùng sang nguồn dữ liệu (nếu cần)
            throw new NotImplementedException();
        }
    }
}
