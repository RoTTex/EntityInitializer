using System;

namespace EntityInitializer
{
	public class IntType : TypeFactory
	{
		public override string FactoryMethod(object propertyValue)
		{
			return propertyValue.ToString(); 
		}
	}
}