using System;

namespace EntityInitializer
{
	public class BoolGenerator : TextGenerator
	{
		public override string Generate(object val)
		{
			return val.ToString().ToLower();
		}
	}
}