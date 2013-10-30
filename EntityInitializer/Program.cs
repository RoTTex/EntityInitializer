using System;
using System.Collections.Generic;

namespace EntityInitializer
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			TestClass test = new TestClass()
			{
				BoolProperty = true,
				DateTimeProperty = DateTime.Now,
				DecimalProperty = 10m,
				DoubleProperty = 10,
				FloatProperty = 10f,
				IntProperty = 10,
				LongProperty = 10,
				StringProperty = "10"
			};

			TestClass test1 = new TestClass()
			{
				BoolProperty = false,
				DateTimeProperty = DateTime.Now,
				DecimalProperty = 20m,
				DoubleProperty = 20,
				FloatProperty = 20f,
				IntProperty = 20,
				LongProperty = 20,
				StringProperty = "20"
			};

			List<TestClass> testList = new List<TestClass>();
			testList.Add(test);
			testList.Add(test1);

			EntityInitializer init = new EntityInitializer();
			string str = init.GetInitializerForSingleEntity(test);
			string strList = init.GetInitializerFor(testList);

		}
	}
}
