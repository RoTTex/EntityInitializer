using System;

namespace EntityInitializer
{
	public class FloatGenerator : TextGenerator
	{
		public override string Generate(object val)
		{
			return val.ToString(); 
		}
	}
}