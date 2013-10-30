using System;

namespace EntityInitializer
{
	public class DoubleType : TypeFactory
	{
		public override string FactoryMethod(object propertyValue)
		{
			return propertyValue.ToString(); 
		}
	}
}