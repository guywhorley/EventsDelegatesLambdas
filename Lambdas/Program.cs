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
			CustomerExample();
			//BizRulesDelegation();
			//ActionExamples();
			//NoParmsLambda();
			//UsingFunc();

			// Exit
			Console.WriteLine("Press Enter");
			Console.ReadLine();
		}

		private static void CustomerExample()
		{
			var custs = new List<Customer>
			{
				new Customer {City = "Phoenix", FirstName = "John", LastName = "Doe", Age = 32},
				new Customer {City = "Phoenix", FirstName = "Jane", LastName = "Doe", Age = 18},
				new Customer {City = "Seattle", FirstName = "Jeff", LastName = "Bezos", Age = 50},
				new Customer {City = "New York City", FirstName = "Frank", LastName = "Sinatra", Age = 99}
			};

			var PhxCusts = custs
				.Where(c => c.City == "Phoenix" && c.Age <30)
				.OrderBy(c => c.FirstName);
			foreach (var customer in PhxCusts)
			{
				Console.WriteLine($"Phoenix customer: {customer.FirstName} {customer.LastName}");
			}
		}

		private static void UsingFunc()
		{
			Func<string, bool> StartsWithVowels;
			StartsWithVowels = CheckStarts;
			bool status = StartsWithVowels("ewok");
			Console.WriteLine($"Ewok starts with vowel: {status}");
		}

		private static bool CheckStarts(string s)
		{
			if (s.StartsWith("a", true, null) || s.StartsWith("e",true,null) || s.StartsWith("i",true,null)
				|| s.StartsWith("o",true,null) || s.StartsWith("y",true,null))
			{
				return true;
			}
			return false;
		}
		

		private static void NoParmsLambda()
		{
			// a lambda with no params
			NoParamsDelegate npd = () =>
			{
				Console.WriteLine("In the No-params delegate.");
				return true;
			};
			Console.WriteLine($"Invoking lambda... return={npd()}");
		}

		private static void ActionExamples()
		{
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
			Action<int, int> myAction = (x, y) => Console.WriteLine($"Adding: 7 + 8 = {x + y}");
			myAction(7, 8);
			//						(param)-> operation - NO RETURN, IS VOID
			Action<string> myStringAction = (s) => Console.WriteLine($"{s}");
			myStringAction("Writing via Action... Chris");
		}

		private static void BizRulesDelegation()
		{
			BizRulesDelegate addDel = (x, y) => x + y;
			BizRulesDelegate multiplyDel = (x, y) => x * y;

			// Will return a value in the last param
			Func<int, int, int> funcAddDel = (x, y) => x + y;
			Func<int, int, int> funcMultiplyDel = (x, y) => x * y;

			ProcessData data = new ProcessData();
			int a = 2;
			int b = 3;

			int result1 = data.ProcessFunc(a, b, funcAddDel);
			int result2 = data.ProcessFunc(a, b, funcMultiplyDel);

			Console.WriteLine($"FuncResult: Added {a} + {b} = {result1}");
			Console.WriteLine($"funcResult: Added {a} * {b} = {result2}");

			Console.WriteLine($"Delegate: Adding {a} + {b} = {data.Process(2, 3, addDel)}");
			Console.WriteLine($"Delegate: Muliplying {a} * {b} = {data.Process(2, 3, multiplyDel)}");
		}
		private static void WriteMyMessage(string message) => Console.WriteLine($"Writing special message: {message}");
		private static void WriteMyInt(int a) => Console.WriteLine($"Writing my number: {a}");

	}
}
