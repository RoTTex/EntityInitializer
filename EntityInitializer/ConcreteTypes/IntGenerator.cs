using System;

namespace EntityInitializer
{
	public class IntGenerator : TextGenerator
	{
		public override string Generate(object val)
		{
			return val.ToString(); 
		}
	}
}