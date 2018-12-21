using System;
using static SimpleExamplesMoka.CoolStuff;

namespace SimpleExamplesMoka
{
	class Program
	{	
		// Event
		public event EventHandler StuffDone;
		
		// Delegates - setting up the delegate 'signature'
		public delegate int ClickHandler(string args);
		public delegate int UpdateHandler(string args);
		public delegate int QueryHandler(string args);
		public delegate int MultiOps(string args);
		public delegate int DoStuffHandler(EventArgs e);
		
		static void Main(string[] args)
		{
			CoolStuff cs = new CoolStuff
			{
				Name = "Chris",
				Age = 50
			};

			ShowStuff(cs);

			int result;
			// Assign handlers to the delegates
			ClickHandler click = new ClickHandler(RespondToClick);
			UpdateHandler update = new UpdateHandler(RespondToUpdate);
			QueryHandler query = new QueryHandler(RespondToQuery);
			MultiOps multiOps = new MultiOps(RespondToClick);
			DoStuffHandler dsh = new DoStuffHandler(GetMyStuffDone);


			multiOps += RespondToUpdate;
			multiOps += RespondToQuery;
			multiOps("triggering multi-operations...");
			
			// Invoke the handlers
			click("button clicked");
			update("database-record update");
			query("query-db");

			


			
			// Clear handlers
			multiOps = NoOps;
			result = multiOps("final");
			Console.WriteLine($"Return value: {result}");

			// Exit
			Console.ReadLine();
		}

		private static int GetMyStuffDone(EventArgs e)
		{
			Console.WriteLine($"Getting mystuff done e:{e.ToString()}");
			return 1;
		}

		// Handlers
		private static int NoOps(string args)
		{
			Console.WriteLine($"NO OPS: {args}");
			return 1;
		}

		private static int RespondToQuery(string args)
		{
			Console.WriteLine($"Responding to query: {args}");
			return 2;
		}

		private static int RespondToUpdate(string args)
		{
			Console.WriteLine($"Responding to update: {args}");
			return 4;
		}
		
		private static int RespondToClick(string args)
		{
			Console.WriteLine($"Responding to click: {args}");
			return 8;
		}


	}
}
