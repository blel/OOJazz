using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOJazz.BusinessLogic
{
    public static class ListExtensions
    {
        public static List<T> RollLeft<T>(this List<T> list, int steps)
        {
            

            List<T> FirstHalf = list.Take(steps).ToList();
            list.RemoveRange(0, steps);
            list.AddRange(FirstHalf);
            return list;
        }

        public static T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argumnent {0} is Not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }

    }
}
