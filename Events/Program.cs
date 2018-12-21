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

			// clients SUBSCRIBING to worker notifications the explicit way
			//worker.SubscribeToNotifications += new EventHandler<MyCustomEventArgs>(DoSomeWorkHandler);
			//worker.SubscribeToNotifications += new EventHandler<MyCustomEventArgs>(AnotherHandler);

			// Build-in shortcut in which EventHandler is assumed 
			worker.SubscribeToNotifications += DoSomeWorkHandler;
			worker.SubscribeToNotifications += AnotherHandler;

			// have the worker go do some work. This will raise an event and trigger
			// the event handlers in the client.
			worker.DoSomeWork("Raise Notification");

			Console.ReadLine();
		}

		// EVENT HANDLERS

		/// <summary>
		/// EventHandler #1.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		static void DoSomeWorkHandler(object sender, MyCustomEventArgs e)
		{
			Console.WriteLine($"Handler1 invoked... doing work:{e.Message}");
		}

		/// <summary>
		/// EventHandler #2.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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
			for (int i = 0; i < 5; i++)
			{
				System.Threading.Thread.Sleep(2000);
				Console.WriteLine($"In DoSomeWork(): Raising OnWorkEventRaiser({str})");
				// raise the event which in turn will signal all the subscribers
				SubscribeToNotifications?.Invoke(this, new MyCustomEventArgs("Responding to work done."));
			}
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
