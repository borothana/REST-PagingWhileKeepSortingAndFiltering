using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Dynamic;

namespace SortingAndFiltering.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string sort)
        {
            if(source == null)
            {
                throw new ArgumentException("Source");
            }

            if(sort == null)
            {
                return source;
            }

            //split the sorting string
            var lstSort = sort.Split(',');

            //run through the sorting options and create a sort expression string from them
            string completeSortExpression = "";
            foreach(var sortOption in lstSort)
            {
                if (sortOption.StartsWith("-"))
                {
                    completeSortExpression += sortOption.Remove(0, 1) + " descending,";
                }
                else
                {
                    completeSortExpression += sortOption + ",";
                }

                if (!string.IsNullOrWhiteSpace(completeSortExpression))
                {
                    source = source.OrderBy(completeSortExpression.Remove(completeSortExpression.Length - 1));
                }
            }

            return source;
        }
    }
}