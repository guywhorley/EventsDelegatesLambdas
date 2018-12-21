using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunicatingBetweenControls.Model;

namespace CommunicatingBetweenControls
{
	/// <summary>
	/// Entity used to communiated between controls keepign very loose coupling.
	/// Keeping sealed so it cannot be overridden.
	/// </summary>
	public sealed class Mediator
	{
		// static members
		// BEGIN SINGLETON SETUP
		private static readonly Mediator _instance = new Mediator();
		
		// Keep contructor private in the singleton pattern.
		private Mediator() {}

		/// <summary>
		/// Get the Mediator singleton.
		/// </summary>
		/// <returns></returns>
		public static Mediator GetInstance() => _instance;
		// END SINGLETON SETUP
	
		// instance functionality
		public event EventHandler<JobChangedEventArgs> JobChanged;

		// What occurs when JobChanged
		public void OnJobChanged(object sender, Job job)
		{
			// get the handler
			// pattern: create event; create On<Event> method; in the method,
			// define delegate = <event> as EventHandler...; Invoke the delegate
			var jobChangedDelegate = JobChanged as EventHandler<JobChangedEventArgs>;
			jobChangedDelegate?.Invoke(sender, new JobChangedEventArgs { Job = job });
		}
	}
}
