
using System.Globalization;

namespace BookLibraryOpenAPI.Org.Converters;
public class ListConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if(value is List<string> list)
        {
            return string.Join(",", list);
        }
        return string.Empty;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

