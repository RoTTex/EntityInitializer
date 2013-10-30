using System;

namespace EntityInitializer
{
	public class FloatType : TypeFactory
	{
		public override string FactoryMethod(object propertyValue)
		{
			return propertyValue.ToString(); 
		}
	}
}