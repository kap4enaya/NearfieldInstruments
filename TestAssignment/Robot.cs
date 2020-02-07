using System;
using System.Windows;
using System.Windows.Controls;
using TestAssignment.ViewModel;

namespace TestAssignment
{
	public class Robot : ContentControl
	{
		public static readonly DependencyProperty TargetProperty = DependencyProperty.Register(
			nameof(Target), typeof(StepViewModel), typeof(Robot), new PropertyMetadata(null, TargetChanged));

		public StepViewModel Target
		{
			get => (StepViewModel)GetValue(TargetProperty);
			set => SetValue(TargetProperty, value);
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

		private static void TargetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if(((StepViewModel)e.NewValue).Duration == default(TimeSpan))
				return;

			((Robot)d).RaiseMovingEvent();
		}
	}
}