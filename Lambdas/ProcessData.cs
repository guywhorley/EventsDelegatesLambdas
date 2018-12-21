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
	}
}
