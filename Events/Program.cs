using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{

	public delegate int DoWork(string str);

	class Program
	{
		static void Main(string[] args)
		{
			Worker worker = new Worker();
			worker.NotifySubscribers += new Worker.SubscribeToNotifications(DoSomeWorkHandler);
			worker.NotifySubscribers += new Worker.SubscribeToNotifications(AnotherHandler);

			worker.DoSomeWork("Raise Notification");

			Console.ReadLine();
		}

		static void DoSomeWorkHandler(string s)
		{
			Console.WriteLine($"Handler1 invoked... doing work {s}");
		}

		static void AnotherHandler(string s)
		{
			Console.WriteLine($"Handler2 invoked... doing work {s}");
		}
	}

	public class Worker
	{
		// events and delegates
		public event SubscribeToNotifications NotifySubscribers;
		public delegate void SubscribeToNotifications(string s);
		
		public int DoSomeWork(string str)
		{
			Console.WriteLine($"In DoSomeWork(): Raising OnWorkEventRaiser({str})");
			NotifySubscribers?.Invoke(str);
			return 1;
		}
	}
}
