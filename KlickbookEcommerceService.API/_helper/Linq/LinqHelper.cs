using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace KlickbookEcommerceService._helper
{
    public static class LinqHelper
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static IEnumerable<TResult> LeftOuterJoin<TSource, TInner, TKey, TResult>(this IEnumerable<TSource> source, IEnumerable<TInner> inner, Func<TSource, TKey> sourcekey, Func<TInner, TKey> innerkey, Func<TSource, TInner, TResult> res)
        {
            //Table1.LeftOuterJoin(Table2, x => x.Key1, x => x.Key2, (x, y) => new { x, y });
            return from f in source
                   join b in inner on sourcekey.Invoke(f) equals innerkey.Invoke(b) into g
                   from result in g.DefaultIfEmpty()
                   select res.Invoke(f, result);
        }

        internal static IEnumerable<Tuple<TLeft, TRight>> LeftJoin<TLeft, TRight, TKey>(
            this IEnumerable<TLeft> left,
            IEnumerable<TRight> right,
            Func<TLeft, TKey> selectKeyLeft,
            Func<TRight, TKey> selectKeyRight,
            TRight defaultRight = default(TRight),
            IEqualityComparer<TKey> cmp = null)
        {
            return left.GroupJoin(
                    right,
                    selectKeyLeft,
                    selectKeyRight,
                    (x, y) => new Tuple<TLeft, IEnumerable<TRight>>(x, y),
                    cmp ?? EqualityComparer<TKey>.Default)
                .SelectMany(
                    x => x.Item2.DefaultIfEmpty(defaultRight),
                    (x, y) => new Tuple<TLeft, TRight>(x.Item1, y));
        }

    }
}
