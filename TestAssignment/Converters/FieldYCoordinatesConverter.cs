using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TestAssignment.Converters
{
	public class FieldYCoordinatesConverter: DependencyObject, IMultiValueConverter
	{
		public static readonly DependencyProperty FieldHeightProperty = DependencyProperty.Register(
			nameof(FieldHeight), typeof(double), typeof(FieldYCoordinatesConverter));

		public static readonly DependencyProperty AxesYValueRangeProperty = DependencyProperty.Register(
			nameof(AxesYValueRange), typeof(double), typeof(FieldYCoordinatesConverter));

		public double FieldHeight
		{
			get => (double) GetValue(FieldHeightProperty);
			set => SetValue(FieldHeightProperty, value);
		}

		public double AxesYValueRange
		{
			get => (double)GetValue(AxesYValueRangeProperty);
			set => SetValue(AxesYValueRangeProperty, value);
		}

		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			var y = (double)values[0];
			var element = (FrameworkElement)values[1];

			var yFactor = Equals(AxesYValueRange, 0d)? 0: FieldHeight / AxesYValueRange;

			return y * yFactor - element.Height / 2;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
