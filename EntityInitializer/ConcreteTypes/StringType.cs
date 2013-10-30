using System;
using System.Text;

namespace EntityInitializer
{
	public class StringType : TypeFactory
	{
		public override string FactoryMethod(object propertyValue)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("\"")
				.Append(propertyValue.ToString().Replace("\"", "\\\""))
				.Append("\"");
			return builder.ToString();
		}
	}
}