using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TestAssignment.Core
{
	internal class ApplicationModel: IApplicationModel
	{
		private readonly List<Point> _points;
		private readonly List<Point> _robots;

		public ApplicationModel()
		{
			_points = new List<Point>();
			_robots = new List<Point>();
		}

		public void AddPoint(Point coordinates)
		{
			_points.Add(coordinates);
		}

		public void AddRobot(Point coordinates)
		{
			_robots.Add(coordinates);
		}

		public IEnumerable<Path> GetPaths()//dummy
		{
			var result = Enumerable.Range(1, _robots.Count).Select(x => new List<Point>()).ToList();

			var random = new Random();
			foreach (var point in _points)
			{
				var index = random.Next(0, _robots.Count);
				result[index].Add(point);
			}

			return result.Select(points => new Path(points));
		}

		public IEnumerable<Point> GetPoints()
		{
			return _points;
		}

		public IEnumerable<Point> GetRobots()
		{
			return _robots;
		}

		public void ClearPoints()
		{
			_points.Clear();
		}
	}
}
