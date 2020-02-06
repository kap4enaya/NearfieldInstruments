using System;
using System.Collections.Generic;
using System.Linq;

namespace TestAssignment.Core
{
	public class ApplicationModel: IApplicationModel
	{
		private readonly List<Point> _points;
		private readonly List<Point> _robots;

		public ApplicationModel(IEnumerable<Point> robots, Point maxPoint, Point minPoint)
		{
			MaxPoint = maxPoint;
			MinPoint = minPoint;
			
			_points = new List<Point>();
			_robots = robots.ToList();

			_robots.ForEach(Validate);
		}

		public Point MaxPoint { get; }
		public Point MinPoint { get; }

		public void AddPoint(Point coordinates)
		{
			Validate(coordinates);

			_points.Add(coordinates);
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

			for (var i = 0; i < _robots.Count; i++)
			{
				var path = result[i];
				if (path.Any())
				{
					path.Insert(0, _robots[i]);
					path.Add(_robots[i]);
				}
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

		private void Validate(Point coordinates)
		{
			if (coordinates.X > MaxPoint.X || coordinates.Y > MaxPoint.Y ||
			    coordinates.X < MinPoint.X || coordinates.Y < MinPoint.Y)
				throw new ArgumentException("Entered coordinates are out of range", nameof(coordinates));
		}
	}
}
