using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Reflection;

namespace KlickbookEcommerceService._helper
{
	public static class ConditionDynamicLinq
	{
		private static IQueryable<TSource> CleanNullValues<TSource>(this IQueryable<TSource> queryable)
		{

			foreach (var item in queryable)
			{
				Type t = item.GetType();
				PropertyInfo[] props = t.GetProperties();
				foreach (var prop in props)
					if (prop.GetIndexParameters().Length == 0)
					{
						if (prop.PropertyType.Name.ToLower().Equals("string"))
						{
							var value = prop.GetValue(item);
							if (value == null)
								prop.SetValue(item, "", null);
								// prop.PropertyType.Name
								// prop.Name
						}
					}
			}
			return queryable;
		}

		public static IQueryable<TSource> WhereCondition<TSource>(this List<TSource> list, string request)
        {

			//var queryable = new List<TSource>(new TSource[] { list }).AsQueryable();
			var queryable = list.AsQueryable();

			var cleanedlist = queryable.CleanNullValues();
			return cleanedlist.Where(request);
        }


		public static IQueryable<TSource> MaxCondition<TSource>(this List<TSource> list, string request)
		{
			//var queryable = new List<TSource>(new TSource[] { list }).AsQueryable();
			var queryable = list.AsQueryable();

			var result = KlickbookEcommerceService._helper.OrderByExtensions.OrderBy(queryable, "-" + request).ToList();
			var value = GetValue(result[0], request);
			var response = WhereCondition(list, request + "=" + value);

			return response;
		}

		public static IQueryable<TSource> MinCondition<TSource>(this List<TSource> list, string request)
		{
			//var queryable = new List<TSource>(new TSource[] { list }).AsQueryable();
			var queryable = list.AsQueryable();

			var result = KlickbookEcommerceService._helper.OrderByExtensions.OrderBy(queryable, request).ToList();
			var value = GetValue(result[0], request);
			var response = WhereCondition(list, request + "=" + value);

			return response;
		}

		public static bool Evaluate<T>(T item, string predicate)
		{
			var l = new List<T>(new T[] { item });
			return l.AsQueryable<T>().Any(predicate);
		}

		public static object GetValue<T>(T item, string property)
		{
			var l = new List<T>(new T[] { item });
			try
			{
				return l.AsQueryable<T>().Select(property).FirstOrDefault();
			}
			catch (System.NullReferenceException)
			{
				return default(T);
			}
		}

		public static object GetPropValue(object source, string propertyName)
		{
			var property = source.GetType().GetRuntimeProperties().FirstOrDefault(p => string.Equals(p.Name, propertyName, StringComparison.OrdinalIgnoreCase));
			return property?.GetValue(source);
		}

		public static object GetPropertyValue(object srcobj, string propertyName)
		{
			//CRM.Staff.Phone[0]
			if (srcobj == null)
				return null;

			object obj = srcobj;

			string[] propertyNameParts = propertyName.Split('.');

			foreach (string propertyNamePart in propertyNameParts)
			{
				if (obj == null) return null;

				if (!propertyNamePart.Contains("["))
				{
					PropertyInfo pi = obj.GetType().GetProperty(propertyNamePart);
					if (pi == null) return null;
					obj = pi.GetValue(obj, null);
				}
				else
				{   
					int indexStart = propertyNamePart.IndexOf("[") + 1;
					string collectionPropertyName = propertyNamePart.Substring(0, indexStart - 1);
					int collectionElementIndex = Int32.Parse(propertyNamePart.Substring(indexStart, propertyNamePart.Length - indexStart - 1));
					PropertyInfo pi = obj.GetType().GetProperty(collectionPropertyName);
					if (pi == null) return null;
					object unknownCollection = pi.GetValue(obj, null);
					if (unknownCollection.GetType().IsArray)
					{
						object[] collectionAsArray = unknownCollection as object[];
						obj = collectionAsArray[collectionElementIndex];
					}
					else
					{
						System.Collections.IList collectionAsList = unknownCollection as System.Collections.IList;
						if (collectionAsList != null)
						{
							obj = collectionAsList[collectionElementIndex];
						}
						else
						{
							return null;
						}
					}
				}
			}

			return obj;
		}

		public static object GetValueExtenssion<T>(this T item, string property)
		{
			var l = new List<T>(new T[] { item });
			try
			{
				return l.AsQueryable<T>().Select(property).FirstOrDefault();
			}
			catch (System.NullReferenceException)
			{
				return default(T);
			}
		}

		public static bool CheckPropertyExistance(Object obj, string property)
		{

			Type t = obj.GetType();
			PropertyInfo[] props = t.GetProperties();
			foreach (var prop in props)
				if (prop.GetIndexParameters().Length == 0)
					if (String.Equals(prop.Name, property, StringComparison.OrdinalIgnoreCase))
						return true;
				
			return false;
		}

		public static string GetProprtyType(Object obj, string property)
		{
			Type t = obj.GetType();
			PropertyInfo[] props = t.GetProperties();
			foreach (var prop in props)
				if (prop.GetIndexParameters().Length == 0)
					if (prop.Name.Equals(property))
						return prop.PropertyType.Name;
						//prop.GetValue(obj)
			return null;
		}
	}
}
