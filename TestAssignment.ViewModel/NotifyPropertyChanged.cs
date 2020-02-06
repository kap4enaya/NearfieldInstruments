using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestAssignment.ViewModel
{
	public class NotifyPropertyChanged : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void CallPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected bool SetProperty<T>(ref T source, T value, [CallerMemberName] string propertyName = null)
		{
			if (!Equals(source, value))
			{
				source = value;
				CallPropertyChanged(propertyName);
				return true;
			}

			return false;
		}
	}
}