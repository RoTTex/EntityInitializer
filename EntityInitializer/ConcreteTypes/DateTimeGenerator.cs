using System;
using System.Text;

namespace EntityInitializer
{
	public class DateTimeGenerator : TextGenerator
	{
		public override string Generate(object val)
		{
			long ticks = ((DateTime)val).Ticks;

			StringBuilder builder = new StringBuilder();
			builder.Append("new DateTime(")
				.Append(ticks.ToString())
				.Append(")");

			return builder.ToString();
		}
	}
}