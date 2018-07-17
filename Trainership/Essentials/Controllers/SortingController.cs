using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Essentials.Controllers
{

    public enum SortingType
    {
        Quicksort,
        MergeSort
    }

    [Route("api/Sorting")]
    public class SortingController : Controller
    {

        /// <summary>
        /// This method sorts received array
        /// </summary>
        /// <param name="sortingType"> The type sort</param>
        /// <param name="array"> Array that will be sort</param>
        /// <returns>Request time</returns>
        [HttpGet]
        public int[] Sort(SortingType sortingType, int[] array)
        {
            switch (sortingType)
            {
                case SortingType.Quicksort:
                    {

                    }
                    break;

                case SortingType.MergeSort:
                    {
                        Merge_Sort(array);
                    }
                    break;
            }
            return array;
        }

        private static Int32[] Merge_Sort(Int32[] massive)
        {
            if (massive.Length == 1)
                return massive;
            Int32 mid_point = massive.Length / 2;
            return Merge(Merge_Sort(massive.Take(mid_point).ToArray()), Merge_Sort(massive.Skip(mid_point).ToArray()));
        }

        private static Int32[] Merge(Int32[] mass1, Int32[] mass2)
        {
            Int32 a = 0, b = 0;
            Int32[] merged = new int[mass1.Length + mass2.Length];
            for (Int32 i = 0; i < mass1.Length + mass2.Length; i++)
            {
                if (b < mass2.Length && a < mass1.Length)
                    if (mass1[a] > mass2[b])
                        merged[i] = mass2[b++];
                    else //if int go for
                        merged[i] = mass1[a++];
                else
                  if (b < mass2.Length)
                    merged[i] = mass2[b++];
                else
                    merged[i] = mass1[a++];
            }
            return merged;
        }
    }
}