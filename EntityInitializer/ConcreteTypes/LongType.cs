using System;

namespace EntityInitializer
{
	public class LongType : TypeFactory
	{
		public override string FactoryMethod(object propertyValue)
		{
			return propertyValue.ToString(); 
		}
	}
}