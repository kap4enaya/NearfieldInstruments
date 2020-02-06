using TestAssignment.Core;

namespace TestAssignment.ViewModel
{
	public class PointViewModel
	{
		public PointViewModel(Point point)
		{
			Point = point;
		}

		public Point Point { get; }

		public bool Visited { get; set; }
	}
}
