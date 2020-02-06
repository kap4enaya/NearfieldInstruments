using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TestAssignment.Converters
{
	public class FieldXCoordinatesConverter: DependencyObject, IMultiValueConverter
	{
		public static readonly DependencyProperty FieldWidthProperty = DependencyProperty.Register(
			nameof(FieldWidth), typeof(double), typeof(FieldXCoordinatesConverter));

		public static readonly DependencyProperty AxesXValueRangeProperty = DependencyProperty.Register(
			nameof(AxesXValueRange), typeof(double), typeof(FieldXCoordinatesConverter));

		public double FieldWidth
		{
			get => (double)GetValue(FieldWidthProperty);
			set => SetValue(FieldWidthProperty, value);
		}

		public double AxesXValueRange
		{
			get => (double)GetValue(AxesXValueRangeProperty);
			set => SetValue(AxesXValueRangeProperty, value);
		}

		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			var x = (double)values[0];
			var element = (FrameworkElement)values[1];

			var xFactor = Equals(AxesXValueRange, 0d) ? 0 : FieldWidth / AxesXValueRange;

			return x * xFactor - element.ActualWidth / 2;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
