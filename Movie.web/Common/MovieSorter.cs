using Movie.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie.web.Common
{
    public static class MovieSorter
    {
        public static List<T> Sort_List<T>(Order sortDirection, string sortExpression, List<T> data)
        {

            List<T> data_sorted = new List<T>();

            if (sortDirection == Order.Ascending)
            {
                data_sorted = (from n in data
                               orderby GetDynamicSortProperty(n, sortExpression) ascending
                               select n).ToList();
            }
            else if (sortDirection == Order.Descending)
            {
                data_sorted = (from n in data
                               orderby GetDynamicSortProperty(n, sortExpression) descending
                               select n).ToList();

            }

            return data_sorted;

        }

        public static object GetDynamicSortProperty(object item, string propName)
        {
            return item.GetType().GetProperty(propName).GetValue(item, null);
        }
    }

    public enum Order
    {
        Ascending,
        Descending
    }
}