using System;
using System.Collections.Generic;
using System.Windows;
using TestAssignment.Core;
using TestAssignment.ViewModel;
using Point = TestAssignment.Core.Point;

namespace TestAssignment
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			var model = new ApplicationModel(new List<Point>
			{
				new Point(0, 100),
				new Point(200, 100)
			}, new Point(200,200), new Point(0,0));
			var viewModel = new MainViewModel(model);
			var window = new MainWindow {DataContext = viewModel};
			window.Show();
		}
	}
}
