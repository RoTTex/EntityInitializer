using System;

namespace EntityInitializer
{
	public class LongGenerator : TextGenerator
	{
		public override string Generate(object val)
		{
			return val.ToString(); 
		}
	}
}