using System.Collections.Generic;
using System.Drawing;

namespace TestAssignment.Core
{
	public interface IApplicationModel
	{
		void AddPoint(Point coordinates);

		void AddRobot(Point coordinates);

		IEnumerable<Path> GetPaths();

		IEnumerable<Point> GetPoints();

		IEnumerable<Point> GetRobots();

		void ClearPoints();
	}
}
