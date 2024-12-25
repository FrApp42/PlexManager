using System.Globalization;

namespace PlexManager.Helpers
{
    public class EqualityConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value?.ToString().Equals(parameter?.ToString(), StringComparison.InvariantCultureIgnoreCase) ?? false;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
