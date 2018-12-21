using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambdas
{
	class Program
	{
		delegate bool NoParamsDelegate();

		static void Main(string[] args)
		{
			// a lambda with no params
			NoParamsDelegate npd = () =>
			{
				Console.WriteLine("In the No-params delegate.");
				return true;
			};
			Console.WriteLine($"Invoking lambda... return={npd()}");
			
			// Exit
			Console.WriteLine("Press Enter");
			Console.ReadLine();
		}
	}
}
