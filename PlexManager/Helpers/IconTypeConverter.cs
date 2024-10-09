using MauiIcons.Material;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace PlexManager.Helpers
{
    internal class IconTypeConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return MaterialIcons.QuestionMark;

            string? formattedValue = value.ToString()?.ToLower();

            return formattedValue switch
            {
                "movie" => MaterialIcons.Movie,
                "show" => MaterialIcons.LiveTv,
                "artist" => MaterialIcons.MusicNote,
                "photo" => MaterialIcons.Image,
                _ => MaterialIcons.QuestionMark
            };
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
