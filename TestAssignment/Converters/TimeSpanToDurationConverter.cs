using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TestAssignment.Converters
{
	public class TimeSpanToDurationConverter: BaseConverter, IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var timeSpan = (TimeSpan) value;
			return new Duration(timeSpan);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var duration = (Duration) value;
			return duration.TimeSpan;
		}
	}
}
