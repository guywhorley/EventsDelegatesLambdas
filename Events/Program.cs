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

			// clients SUBSCRIBING to worker notifications the explicit way - (No Delegate Inference)
			//worker.SubscribeToNotifications += new EventHandler<MyCustomEventArgs>(DoSomeWorkHandler);
			//worker.SubscribeToNotifications += new EventHandler<MyCustomEventArgs>(AnotherHandler);

			// WIRE UP HANDLERS
			// Build-in shortcut in which EventHandler is assumed - Using "DELEGATE INFERENCE"
			worker.SubscribeToNotifications += DoSomeWorkHandler;
			worker.SubscribeToNotifications += AnotherHandler;
			worker.SubscribeToNotifications += SomeMoreWorkToReportHandler;
			worker.SubscribeToNotifications -= AnotherHandler;
			worker.WorkCompleted += NotifyWorkCompleted;

			// ANONYMOUS DELEGATE Approach defined at the source. Cannot be attached to other events.
			// Can be used for uber-simple code to run when event fires.
			worker.SubscribeToNotifications += delegate(object sender, MyCustomEventArgs e)
			{
				Console.WriteLine($"Anonymous Handler invoked... {e.Message}");
			};

			// have the worker go do some work. This will raise an event and trigger
			// the event handlers in the client.
			worker.DoSomeWork("Raise Notification");
			Console.ReadLine();
		}

		/// <summary>
		/// Client work to perform when all the work has been completed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void NotifyWorkCompleted(object sender, MyCustomEventArgs e)
		{
			Console.WriteLine(e.Message);
		}

		// EVENT HANDLERS

		/// <summary>
		/// EventHandler #1.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		static void DoSomeWorkHandler(object sender, MyCustomEventArgs e)
		{
			Console.WriteLine($"Handler1 invoked... {e.Message}");
		}

		/// <summary>
		/// EventHandler #2.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		static void AnotherHandler(object sender, MyCustomEventArgs e)
		{
			Console.WriteLine($"Handler2 invoked... {e.Message}");
		}

		/// <summary>
		/// Yet another handler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private static void SomeMoreWorkToReportHandler(object sender, MyCustomEventArgs e)
		{
			Console.WriteLine($"Handler-N... {e.Message}");
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
		public event EventHandler<MyCustomEventArgs> WorkCompleted;
		
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
				// raise the event which in turn will signal all the subscribers; can pass back
				// data in the CustomEventArgs
				SubscribeToNotifications?.Invoke(this, new MyCustomEventArgs("Responding to work done."));
			}

			// raise completion event
			WorkCompleted?.Invoke(this, new MyCustomEventArgs("Work has finished."));
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
