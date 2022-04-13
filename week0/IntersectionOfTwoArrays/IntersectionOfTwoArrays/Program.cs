using System;
using System.Collections.Generic;
using System.Linq;

namespace IntersectionOfTwoArrays
{
    internal class Program
    {
        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            var returnList = new List<int>();
            var list = new List<int>();

            foreach (var item in nums2)
            {
                list.Add(item);
            }

            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (nums1[i] == list[j])
                    {
                        returnList.Add(list[j]);
                        list.RemoveAt(j);
                        break;
                    }
                }
            }

            return returnList.ToArray();
        }
        static void Main(string[] args)
        {
            int[] nums1 = new int[] { 1, 2, 2, 1 };
            int[] nums2 = new int[] { 1, 2 };

            var newArr = Intersect(nums1, nums2);

            foreach (var item in newArr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
