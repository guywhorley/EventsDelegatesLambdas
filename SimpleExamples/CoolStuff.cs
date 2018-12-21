using System;

namespace SimpleExamplesMoka
{
	class CoolStuff
	{
		public string Name { get; set; }
		public int Age { get; set; }

		public override string ToString() => $"{{Name:{this.Name}, Age:{this.Age}}}";

		public static void ShowStuff(CoolStuff cs)
		{
			Console.WriteLine($"This:{nameof(cs)} ToString:{cs}");
		}
	}
}
