using System;
using System.Text;

namespace EntityInitializer
{
	public class DateTimeType : TypeFactory
	{
		public override string FactoryMethod(object propertyValue)
		{
			long ticks = ((DateTime)propertyValue).Ticks;
			StringBuilder builder = new StringBuilder();
			builder.Append("new DateTime(")
				.Append(ticks.ToString())
				.Append(")");

			return builder.ToString();
		}
	}
}