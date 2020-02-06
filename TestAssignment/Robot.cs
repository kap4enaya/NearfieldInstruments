using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestAssignment
{
	public class Robot : ContentControl
	{
		public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register(
			nameof(IsActive), typeof(bool), typeof(Robot), new PropertyMetadata(false, IsActiveChanged));

		public bool IsActive
		{
			get => (bool)GetValue(IsActiveProperty);
			set => SetValue(IsActiveProperty, value);
		}

		public static readonly RoutedEvent MovingEvent = EventManager.RegisterRoutedEvent(
			nameof(Moving), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Robot));

		public event RoutedEventHandler Moving
		{
			add => AddHandler(MovingEvent, value);
			remove => RemoveHandler(MovingEvent, value);
		}

		private void RaiseMovingEvent()
		{
			var newEventArgs = new RoutedEventArgs(MovingEvent);
			RaiseEvent(newEventArgs);
		}

		private static void IsActiveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((Robot)d).RaiseMovingEvent();
		}
	}
}