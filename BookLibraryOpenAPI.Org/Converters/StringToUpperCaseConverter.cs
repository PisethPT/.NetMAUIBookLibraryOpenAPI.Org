using System.Diagnostics;
using System.Globalization;

namespace BookLibraryOpenAPI.Org.Converters;
public class StringToUpperCaseConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is List<string> list)
        {
            var result = string.Join(", ", list);
            return result.ToUpper();
        }
        return string.Empty;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

