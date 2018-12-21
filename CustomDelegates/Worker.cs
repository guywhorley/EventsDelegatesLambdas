using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDelegates
{
	public class Worker
	{
		//public event WorkPerformedHandler WorkPerformed;
		public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
		public event EventHandler WorkCompleted;
		

		// Do some work here
		public void DoWork(string greeting, WorkType workType)
		{
			int temp = 1;

			for (int i = 0; i < 4; i++)
			{
				OnWorkPerformed($"WorkPerformed {temp++}", WorkType.Work);
			}

			OnWorkCompleted($"WorkCompleted", WorkType.Shopping);
		}
		
		protected virtual void OnWorkPerformed(string greeting, WorkType WT)
		{	
			
			//WorkPerformed("WorkPerformed", WorkType.Shopping);
		}

		protected virtual void OnWorkCompleted(string greeting, WorkType WT)
		{
			var del = WorkCompleted as EventHandler;
			if (del != null)
			{
				del(this, EventArgs.Empty);
			}
		}
	}

}
