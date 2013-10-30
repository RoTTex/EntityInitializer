using System;

namespace EntityInitializer
{
	public class DoubleGenerator : TextGenerator
	{
		public override string Generate(object val)
		{
			return val.ToString(); 
		}
	}
}