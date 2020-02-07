using TestAssignment.Core;

namespace TestAssignment.ViewModel
{
	public class PointViewModel: NotifyPropertyChanged
	{
		public PointViewModel(Point point)
		{
			Point = point;
		}

		public Point Point { get; }

		public bool Visited
		{
			get => _visited;
			private set => SetProperty(ref _visited, value);
		}
		private bool _visited;

		public RobotViewModel VisitingRobot
		{
			get => _visitingRobot;
			private set => SetProperty(ref _visitingRobot, value);
		}
		private RobotViewModel _visitingRobot;

		public void Visit(RobotViewModel visitingRobot)
		{
			VisitingRobot = visitingRobot;
			Visited = true;
		}
	}
}
