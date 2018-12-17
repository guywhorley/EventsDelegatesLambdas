using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDelegates
{
	class Program
	{
		// delegate definition
		public delegate int DoTheWorkHandler(string str1, WorkType wt);

		public static void Main(string[] args)
		{
			// Wiring up the delegate pipeline to event handler.
			DoTheWorkHandler del = new DoTheWorkHandler(DoTheWork);
			DoTheWorkHandler del1 = new DoTheWorkHandler(DoOtherWork);
			DoTheWorkHandler del2 = new DoTheWorkHandler(DoYetMoreWork);
			
			// order matters on multicast delegate
			del += del1 + del2;

			// FYI: the last delegate return value is the one that is used. They are not 'accumulated'.
			int finalHours = del("Chris", WorkType.Shopping);
			Console.WriteLine($"finalHours: {finalHours}");
			
			
			
			
			
			Console.Read(); // Exit run
		}

		// Invoke the delegate
		static void DoWork(DoTheWorkHandler del) => del("Chris", WorkType.Work);

		// handlers --- the method that actually does the work.
		static int DoTheWork(string greeting, WorkType wt)
		{
			Console.WriteLine($"1) Do work one way: {greeting}. Here is your worktype: {wt.ToString()}");
			return 1;
		}

		static int DoOtherWork(string greeting, WorkType wt)
		{
			Console.WriteLine($"2) Do Other Work a different way: {greeting}");
			return 2;
		}
		static int DoYetMoreWork(string str1, WorkType wt)
		{
			Console.WriteLine($"3) Doing the work a third way {str1}");
			return 3;
		}
	}

	public enum WorkType
	{
		NONE,
		Shopping,
		Work
	}
}
