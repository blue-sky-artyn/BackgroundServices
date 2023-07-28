using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic;
using Microsoft.EntityFrameworkCore;


namespace KlickbookEcommerceService._helper
{
    public static class HelpersSelect
    {
        public static dynamic DynamicSelectGenerator<T>(string Fields = "")
        {
            //if (Fields == null)
            //    throw new ArgumentNullException("Fields ");

            string[] EntityFields;
            if (Fields == "")
                // get Properties of the T
                EntityFields = typeof(T).GetProperties().Select(propertyInfo => propertyInfo.Name).ToArray();
            else
                EntityFields = Fields.Split(',');

            // input parameter "o"
            var xParameter = Expression.Parameter(typeof(T), "o");

            // new statement "new Data()"
            var xNew = Expression.New(typeof(T));

            // create initializers
            var bindings = EntityFields.Select(o => o.Trim())
                .Select(o =>
                {

                        // property "Field1"
                    var mi = typeof(T).GetProperty(o);

                        // original value "o.Field1"
                    var xOriginal = Expression.Property(xParameter, mi);

                        // set value "Field1 = o.Field1"
                    return Expression.Bind(mi, xOriginal);
                }
            );

            // initialization "new Data { Field1 = o.Field1, Field2 = o.Field2 }"
            var xInit = Expression.MemberInit(xNew, bindings);

            // expression "o => new Data { Field1 = o.Field1, Field2 = o.Field2 }"
            var lambda = Expression.Lambda<Func<T, T>>(xInit, xParameter);

            // compile to Func<Data, Data>
            return lambda.Compile();
        }

        //Dynamic LINQ
        public static List<dynamic> DynamicSelect<TSource>(this List<TSource> source, string request)
            =>  source.AsQueryable().Select("new {" + request+ "}").ToDynamicList();
        public static List<dynamic> DynamicSelectMethod<TSource>(List<TSource> source, string request)
           => source.AsQueryable().Select("new {" + request + "}").ToDynamicList();

    }
}
