using System;

namespace TestAssignment.Core
{
	/// <summary>
	/// Calculates the distance between two points using the Pythagorean theorem
	/// </summary>
	public class DistanceComputer
	{
		public double GetDistance(Point pointA, Point pointB)
		{
			var sideA = pointA.X - pointB.X;
			var sideB = pointA.Y - pointB.Y;
			var hypotenuse = Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));

			return hypotenuse;
		}
	}
}
