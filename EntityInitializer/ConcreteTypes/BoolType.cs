using System;

namespace EntityInitializer
{
	public class BoolType : TypeFactory
	{
		public override string FactoryMethod(object propertyValue)
		{
			return propertyValue.ToString().ToLower();
		}
	}
}