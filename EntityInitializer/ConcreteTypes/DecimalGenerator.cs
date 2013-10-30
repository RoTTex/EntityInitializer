using System;

namespace EntityInitializer
{
	public class DecimalGenerator : TextGenerator
	{
		public override string Generate(object val)
		{
			return string.Format("{0}m", val);
		}
	}
}