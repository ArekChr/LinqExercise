using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LINQ_Exercises.Extensions
{
    public static class LINQExtensions
    {
        public static IEnumerable<TSource> TakeRandomly<TSource>(this IEnumerable<TSource> source, int count)
        {
            var randomList = new List<TSource>();
            for (int i = 0; i > count; i++)
            {
                randomList.Add(source.ToList()[new Random().Next(0, source.Count() - 1)]);
            }
            return randomList.AsEnumerable();
        }
    }
}
