using System;
using System.Collections.Generic;

namespace TestAssignment.Core
{
	public interface IApplicationModel
	{
		/// <summary>
		/// Defines the top value for X and Y
		/// </summary>
		Point MaxPoint { get; }
		/// <summary>
		/// Defines the lowest value for X and Y
		/// </summary>
		Point MinPoint { get; }
		/// <summary>
		/// Adds a new point to the field.
		/// Throws <see cref="ArgumentException"/> if the specified coordinates are 
		/// outside of the allowed range defined by <see cref="MaxPoint"/> and <see cref="MinPoint"/>
		/// </summary>
		void AddPoint(Point coordinates);
		/// <summary>
		/// Returns a full route for each robot.
		/// The route starts and ends at the robot's initial location.
		/// The order of the paths is guaranteed to be the same as the order of <see cref="GetRobots"/>
		/// </summary>
		IEnumerable<Path> GetPaths();
		/// <summary>
		/// Returns all the points on the field
		/// </summary>
		IEnumerable<Point> GetPoints();
		/// <summary>
		/// Returns initial coordinates of robots
		/// </summary>
		IEnumerable<Point> GetRobots();
		/// <summary>
		/// Removes all the points from the field
		/// </summary>
		void ClearPoints();
	}
}
