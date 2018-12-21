using CommunicatingBetweenControls.Model;
using System;

namespace CommunicatingBetweenControls
{
	public class JobChangedEventArgs : EventArgs
	{
		public Job Job { get; set; }
	}
}