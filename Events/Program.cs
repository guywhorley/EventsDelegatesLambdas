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
		static void DoSomeWorkHandler(object sender, MyCustomEventArgs e)
		{
			Console.WriteLine($"Handler1 invoked... doing work:{e.Message}");
		}

		static void AnotherHandler(object sender, MyCustomEventArgs e)
		{
			Console.WriteLine($"Handler2 invoked... doing work:{e.Message}");
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
		//public event EventHandler SubscribeToNotifications; // using standard EventArgs
		// built-in EventHandler<T> - here, you DO NOT define the delegate
		public event EventHandler<MyCustomEventArgs> SubscribeToNotifications; // custom EventArgs
		
		// using the approach where you explicitly define a handler. 
		//public event SubscribeNotifyHandler SubscribeToNotifications;
		//public delegate void SubscribeNotifyHandler(object sender, MyCustomEventArgs args);

		/// <summary>
		/// Do some work and when done, raise a notification.
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public int DoSomeWork(string str)
		{
			Console.WriteLine($"In DoSomeWork(): Raising OnWorkEventRaiser({str})");
			// raise the event which in turn will signal all the subscribers
			//SubscribeToNotifications(this, EventArgs.Empty);
			SubscribeToNotifications?.Invoke(this, new MyCustomEventArgs("MyCustomEventArgsMessage"));
			return 1;
		}
	}

	/// <summary>
	/// My custom EventArgs containing all the things I care about.
	/// </summary>
	public class MyCustomEventArgs : EventArgs
	{
		public MyCustomEventArgs(string message) => Message = message;

		public string Message { get; private set; }
	}
}
