using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEvents
{
	class Program
	{
		// Events
		public event EventHandler MyEvent
		{
			add { Console.WriteLine("add operation"); }
			remove { Console.WriteLine("remove operation"); }
		}

		public static void Main(string[] args)
		{
			Program p = new Program();
			p.MyEvent += new EventHandler(p.WriteMessage);
			p.MyEvent -= null;
			
			Console.ReadLine();
		}

		void WriteMessage(object sender, EventArgs e)
		{
			Console.WriteLine($"Sender: {sender} e: {e.ToString()}");
		}
	}

	
}
