using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAssignment.Core;

namespace TestAssignment.ViewModel
{
	public class RobotViewModel: NotifyPropertyChanged
	{
		public RobotViewModel(Point initialCoordinates)
		{
			InitialCoordinates = new PointViewModel(initialCoordinates);
			CurrentStep = new StepViewModel(InitialCoordinates, 0);
		}

		public PointViewModel InitialCoordinates { get; }

		public StepViewModel CurrentStep
		{
			get =>_currentStep;
			private set => SetProperty(ref _currentStep, value);
		}
		private StepViewModel _currentStep;

		public async Task Simulate(Path path, IReadOnlyList<PointViewModel> pointVMs)
		{
			foreach (var step in CreateSteps(path, pointVMs))
			{
				CurrentStep = step;
				await Task.Delay(CurrentStep.Duration);
				CurrentStep.Destination.Visit(this);
			}
		}

		private IEnumerable<StepViewModel> CreateSteps(Path path, IReadOnlyList<PointViewModel> pointVMs)
		{
			var points = path.Points.ToList();
			var distanceComputer = new DistanceComputer();
			for (var i = 0; i < points.Count - 1; i++)
			{
				var start = points[i];
				var destination = points[i + 1];
				var distance = distanceComputer.GetDistance(start, destination);
				var destinationVm = pointVMs.FirstOrDefault(point => Equals(point.Point, destination)) ??
				                    InitialCoordinates;

				yield return new StepViewModel(destinationVm, distance);
			}
		}
	}
}
