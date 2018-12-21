using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambdas
{
	// Delegate signatures
	delegate bool NoParamsDelegate();

	public delegate int BizRulesDelegate(int x, int y);

	class Program
	{
		static void Main(string[] args)
		{
			// Define Business Rules
			BizRulesDelegate addDel = (x, y) => x + y;
			BizRulesDelegate multiplyDel = (x, y) => x * y;

			// a lambda with no params
			NoParamsDelegate npd = () =>
			{
				Console.WriteLine("In the No-params delegate.");
				return true;
			};
			Console.WriteLine($"Invoking lambda... return={npd()}");

			ProcessData data = new ProcessData();
			int a = 2;
			int b = 3;

			Console.WriteLine($"Adding {a} + {b} = {data.Process(2, 3, addDel)}");
			Console.WriteLine($"Muliplying {a} * {b} = {data.Process(2, 3, multiplyDel)}");
			
			// Exit
			Console.WriteLine("Press Enter");
			Console.ReadLine();
		}
	}
}
