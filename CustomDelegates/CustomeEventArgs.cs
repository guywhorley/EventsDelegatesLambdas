using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDelegates
{
	public class WorkPerformedEventArgs : System.EventArgs
	{
		public WorkPerformedEventArgs(string greeting, WorkType workType)
		{
			Greeting = greeting;
			WorkType = workType;
		}

		public string Greeting { get; set;}
		public WorkType WorkType { get; set;}
	}
}
