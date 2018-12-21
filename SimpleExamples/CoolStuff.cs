using System;

namespace SimpleExamplesMoka
{
	public delegate int DoCoolStuffHandler(string s);

	class CoolStuff
	{
		public event DoCoolStuffHandler CoolStuffDone;
		
		public string Name { get; set; }
		public int Age { get; set; }

		public override string ToString() => $"{{Name:{this.Name}, Age:{this.Age}}}";

		public static void ShowStuff(CoolStuff cs)
		{
			Console.WriteLine($"This:{nameof(cs)} ToString:{cs}");
		}

		public void DoCoolWork(string s)
		{
			OnCoolStuffDone("hello");
		}

		// event handlers
		protected virtual int OnCoolStuffDone(string s)
		{
			CoolStuffDone?.Invoke("Hello Chris");

			return 1;
		}

	}
}
