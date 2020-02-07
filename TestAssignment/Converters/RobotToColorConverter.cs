using System;
using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using TestAssignment.ViewModel;

namespace TestAssignment.Converters
{
	public class RobotToColorConverter: BaseConverter, IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			var robot = (RobotViewModel)values[0];
			var robotsCanvas = (Canvas)values[1];

			var robots = robotsCanvas.Children.OfType<Robot>().ToList();
			return robots.First(x => x.Tag == robot).Foreground;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
