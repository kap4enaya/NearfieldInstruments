using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TestAssignment.Core.Test
{
	public class ApplicationModelTest
	{
		private IApplicationModel _applicationModel;

		[SetUp]
		public void Setup()
		{
			_applicationModel = new ApplicationModel(new List<Point>
				{
					new Point(0, 0),
					new Point(200, 0)
				},
				new Point(200, 200), 
				new Point(0, 0));
		}

		[Test]
		public void TestAddPoint_InvalidRange()
		{
			Assert.Throws<ArgumentException>(() => _applicationModel.AddPoint(new Point(0, 201)));
			Assert.Throws<ArgumentException>(() => _applicationModel.AddPoint(new Point(201, 0)));
		}

		[Test]
		public void TestAllPointsVisitedOnce()
		{
			_applicationModel.AddPoint(new Point(5,5));
			_applicationModel.AddPoint(new Point(10, 10));
			_applicationModel.AddPoint(new Point(20, 20));
			_applicationModel.AddPoint(new Point(40, 40));
			_applicationModel.AddPoint(new Point(80, 80));

			var paths = _applicationModel.GetPaths().ToList();
			Assert.AreEqual(1, paths.Count(path => path.Points.Count(point => Equals(point, new Point(5, 5))) == 1));
			Assert.AreEqual(1, paths.Count(path => path.Points.Count(point => Equals(point, new Point(10, 10))) == 1));
			Assert.AreEqual(1, paths.Count(path => path.Points.Count(point => Equals(point, new Point(20, 20))) == 1));
			Assert.AreEqual(1, paths.Count(path => path.Points.Count(point => Equals(point, new Point(40, 40))) == 1));
			Assert.AreEqual(1, paths.Count(path => path.Points.Count(point => Equals(point, new Point(80, 80))) == 1));
		}

		[Test]
		public void TestPathsStartAndEndPoints()
		{
			_applicationModel.AddPoint(new Point(5, 5));
			_applicationModel.AddPoint(new Point(10, 10));
			_applicationModel.AddPoint(new Point(20, 20));
			_applicationModel.AddPoint(new Point(40, 40));
			_applicationModel.AddPoint(new Point(80, 80));

			var robots = _applicationModel.GetRobots().ToList();
			var paths = _applicationModel.GetPaths().ToList();

			if (paths[0].Points.Any())
			{
				Assert.AreEqual(robots[0], paths[0].Points.First());
				Assert.AreEqual(robots[0], paths[0].Points.Last());
			}

			if (paths[1].Points.Any())
			{
				Assert.AreEqual(robots[1], paths[1].Points.First());
				Assert.AreEqual(robots[1], paths[1].Points.Last());
			}
		}
	}
}