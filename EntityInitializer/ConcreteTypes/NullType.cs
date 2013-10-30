using System;

namespace EntityInitializer
{
	public class NullType : TypeFactory
	{
		public override string FactoryMethod(object propertyValue)
		{
			return "null";
		}
	}
}

