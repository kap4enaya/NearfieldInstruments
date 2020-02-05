using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TestAssignment.Core
{
	public class Path
	{
		public Path(IEnumerable<Point> points)
		{
			Points = points.ToList();
		}

		public IEnumerable<Point> Points { get; }
	}
}
