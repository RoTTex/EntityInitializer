using System;
using System.Text;

namespace EntityInitializer
{
	public class StringGenerator : TextGenerator
	{
		public override string Generate(object val)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("\"")
				.Append(val.ToString().Replace("\"", "\\\""))
				.Append("\"");
			return builder.ToString();
		}
	}
}