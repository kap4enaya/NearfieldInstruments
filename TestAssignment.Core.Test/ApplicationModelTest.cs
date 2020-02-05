using System.Drawing;
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
			_applicationModel = new ApplicationModel();
			_applicationModel.AddRobot(new Point(0,0));
			_applicationModel.AddRobot(new Point(200, 0));
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
			Assert.AreEqual(1, paths.Count(path => path.Points.Count(point => point == new Point(5, 5)) == 1));
			Assert.AreEqual(1, paths.Count(path => path.Points.Count(point => point == new Point(10, 10)) == 1));
			Assert.AreEqual(1, paths.Count(path => path.Points.Count(point => point == new Point(20, 20)) == 1));
			Assert.AreEqual(1, paths.Count(path => path.Points.Count(point => point == new Point(40, 40)) == 1));
			Assert.AreEqual(1, paths.Count(path => path.Points.Count(point => point == new Point(80, 80)) == 1));
		}
	}
}