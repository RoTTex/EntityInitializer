using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace EntityInitializer
{
	public class EntityInitializer
	{
		Dictionary<Type, TypeFactory> types;

		public EntityInitializer()
		{
			types = new Dictionary<Type, TypeFactory>()
			{
				{ typeof(string), new StringType() },
				{ typeof(bool), new BoolType() },
				{ typeof(DateTime), new DateTimeType() },
				{ typeof(decimal), new DecimalType() },
				{ typeof(double), new DoubleType() },
				{ typeof(float), new FloatType() },
				{ typeof(int), new IntType() },
				{ typeof(long), new LongType() }
			};
		}

		public string GetInitializerForSingleEntity<T>(T entity)
		{
			StringBuilder builder = new StringBuilder();
			GetInitializerForSingleEntity(entity, builder);

			return builder.ToString();
		}

		private void GetInitializerForSingleEntity<T>(T entity, StringBuilder builder)
		{
			Type type = typeof(T);
			GetInitializerForSingleEntity(type, entity, builder);
		}

		public void GetInitializerForSingleEntity(Type entityType, object entity, StringBuilder builder)
		{
			PropertyInfo[] properties = entityType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

			string friendlyTypeName = GetFriendlyName(entityType);
			builder.Append("new ")
				.AppendLine(friendlyTypeName)
					.AppendLine("{");

			foreach(PropertyInfo p in properties)
			{
				if(!p.CanRead || !p.CanWrite)
					continue;

				builder.Append("\t");
				builder.Append(p.Name)
					.Append(" = ");

				object propertyValue = p.GetValue(entity, null);
				Type propeptyType = p.PropertyType;

				builder.Append(types[propeptyType].FactoryMethod(propertyValue));

				if(propertyValue == null)
				{
					builder.Append("null");
				}
				else if(propeptyType == typeof(string))
				{
					builder.Append("\"")
						.Append(propertyValue.ToString().Replace("\"", "\\\""))
							.Append("\"");
				}
				else if(propeptyType == typeof(bool))
				{
					builder.Append(propertyValue.ToString().ToLower());
				}
				else if(propeptyType == typeof(decimal))
				{
					builder.Append(string.Format("{0}m", propertyValue));

				}
				else if(propeptyType == typeof(int)
				        || propeptyType == typeof(float)
				        || propeptyType == typeof(double)
				        || propeptyType == typeof(long))
				{
					builder.Append(propertyValue.ToString());
				}
				else if(propeptyType == typeof(DateTime))
				{
					long ticks = ((DateTime)propertyValue).Ticks;
					builder.Append("new DateTime(")
						.Append(ticks.ToString())
							.Append(")");
				}
				else if(propeptyType.GetInterfaces().Contains(typeof(IList)))
				{
					Type argType = propeptyType.GetGenericArguments()[0];
					WriteInitializerForIList(argType, (IList)propertyValue, builder);
				}
				else
				{
					GetInitializerForSingleEntity(propeptyType, propertyValue, builder);

				}
				builder.AppendLine(",");
			}

			builder.Append("}");
		}

		public string GetInitializerFor<T>(List<T> entities)
		{
			StringBuilder sb = new StringBuilder();

			Type type = typeof(T);
			WriteInitializerForIList(type, entities, sb);

			return sb.ToString();
		}

		private void WriteInitializerForIList(Type entityType, IList entities, StringBuilder builder)
		{
			string friendlyTypeName = GetFriendlyName(entities.GetType());
			builder.Append("new ")
				.AppendLine(friendlyTypeName)
					.AppendLine("{");

			foreach(var e in entities)
			{
				GetInitializerForSingleEntity(entityType, e, builder);
				builder.AppendLine(",");
			}

			builder.Append("}");
		}

		public static string GetFriendlyName(Type type)
		{
			if (type == typeof(int))
				return "int";
			else if (type == typeof(short))
				return "short";
			else if (type == typeof(byte))
				return "byte";
			else if (type == typeof(bool)) 
				return "bool";
			else if (type == typeof(long))
				return "long";
			else if (type == typeof(float))
				return "float";
			else if (type == typeof(double))
				return "double";
			else if (type == typeof(decimal))
				return "decimal";
			else if (type == typeof(string))
				return "string";
			else if (type.IsGenericType)
				return type.Name.Split('`')[0] + "<" + string.Join(", ", type.GetGenericArguments().Select(x => GetFriendlyName(x))) + ">";
			else
				return type.Name;
		}
	}
}

