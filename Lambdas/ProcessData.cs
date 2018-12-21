using System;

namespace Lambdas
{
	class ProcessData
	{
		/// <summary>
		/// Calculate x,y according to business rules.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="del"></param>
		public int Process(int x, int y, BizRulesDelegate del) => del(x, y);

		public void ProcessAction(int x, int y, Action<int, int> action)
		{
			action(x, y);
			Console.WriteLine("Action has been processed.");
		}

		public int ProcessFunc(int x, int y, Func<int, int, int> func)
		{
			Console.WriteLine($"Func invoked.");
			return func(x, y);
		}

		public void ProcessSomeOtherAction(string str, Action<string> action)
		{
			action(str);
		}
	}
}
