using System.Globalization;

namespace PlexManager.Helpers
{
    public class BigIntToTimeString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is long seconds)
            {
                TimeSpan time = TimeSpan.FromMilliseconds(seconds);
                return time.ToString(@"hh\:mm\:ss");
            }

            return "00:00:00";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string timeString && TimeSpan.TryParseExact(timeString, @"hh\:mm\:ss", culture, out TimeSpan time))
            {
                return (long)time.TotalSeconds;
            }

            return 0L;
        }
    }
}
