using System;

namespace EntityInitializer
{
	public class DecimalType : TypeFactory
	{
		public override string FactoryMethod(object propertyValue)
		{
			return string.Format("{0}m", propertyValue);
		}
	}
}