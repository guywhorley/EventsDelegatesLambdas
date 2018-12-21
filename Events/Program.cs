using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
	class Program
	{
		static void Main(string[] args)
		{
			Worker worker = new Worker();

			// clients SUBSCRIBING to worker notifications
			worker.SubscribeToNotifications += DoSomeWorkHandler;
			worker.SubscribeToNotifications += AnotherHandler;

			// have the worker go do some work. This will raise an event and trigger
			// the event handlers in the client.
			worker.DoSomeWork("Raise Notification");

			Console.ReadLine();
		}

		// EVENT HANDLERS

		// Using the standard Event pattern where the handlers use sender, args format.
		static void DoSomeWorkHandler(object sender, EventArgs e)
		{
			Console.WriteLine($"Handler1 invoked... doing work {e}");
		}

		static void AnotherHandler(object sender, EventArgs e)
		{
			Console.WriteLine($"Handler2 invoked... doing work {e}");
		}
	}

	/// <summary>
	/// Some service that performs work and allows for subscribing to notifications.
	/// </summary>
	public class Worker
	{
		// events and delegates
		
		// the event must reference a delegate
		/// <summary>
		/// Raise a notification to subscribers
		/// </summary>
		public event EventHandler SubscribeToNotifications;
		
		public int DoSomeWork(string str)
		{
			Console.WriteLine($"In DoSomeWork(): Raising OnWorkEventRaiser({str})");
			// raise the event which in turn will signal all the subscribers
			if (SubscribeToNotifications != null)
			{
				SubscribeToNotifications(this, EventArgs.Empty);
			}

			return 1;
		}
	}
}
