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
			// Define Business Rules for math
			//BizRulesDelegate addDel = (x, y) => x + y;
			//BizRulesDelegate multiplyDel = (x, y) => x * y;
			//ProcessData data = new ProcessData();
			//int a = 2;
			//int b = 3;

			//Console.WriteLine($"Adding {a} + {b} = {data.Process(2, 3, addDel)}");
			//Console.WriteLine($"Muliplying {a} * {b} = {data.Process(2, 3, multiplyDel)}");
		
			// ACTIONS
			// Action<T> - takes a single parameter and does not return anything. Built-in to .NET
			Action<string> messageTarget;
			Action<int> intTarget;
			Action<string> WriteString;
			Action<object> WriteObject;

			// technique for passing in param automatically. The Action passes in the single param into Console.Writeline.
			WriteString = Console.WriteLine;
			WriteString("Console.Writeline: Hello from Action...");
			WriteObject = Console.WriteLine;
			WriteObject("Console.Writeline(object) -> chris");
			WriteObject(7);

			messageTarget = WriteMyMessage;
			messageTarget("Invoking action...");
			intTarget = WriteMyInt;
			intTarget(7);

			// EXAMPLE: Defining the action signatures and calling
			Action<int, int> myAction = (x, y) => Console.WriteLine($"Adding: 7 + 8 = {x+y}");
			myAction(7, 8);
			//						(param)-> operation - NO RETURN, IS VOID
			Action<string> myStringAction = (s) => Console.WriteLine($"{s}");
			myStringAction("Writing via Action... Chris");


			// a lambda with no params
			//NoParamsDelegate npd = () =>
			//{
			//	Console.WriteLine("In the No-params delegate.");
			//	return true;
			//};
			//Console.WriteLine($"Invoking lambda... return={npd()}");


			// Exit
			Console.WriteLine("Press Enter");
			Console.ReadLine();
		}

		private static void WriteMyMessage(string message) => Console.WriteLine($"Writing special message: {message}");
		private static void WriteMyInt(int a) => Console.WriteLine($"Writing my number: {a}");

	}
}
