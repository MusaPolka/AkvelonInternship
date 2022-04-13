using System;

namespace RotateArray
{
    internal class Program
    {
        public static int[] Rotate(int[] nums, int k)
        {
            int [] nums2 = new int[nums.Length];
            int rotateFrom = nums.Length - k;
            int index = 0;

            for (int i = 0; i < k; i++)
            {
                nums2[i] = nums[index + rotateFrom];
                index++;
            }

            for (int i = 0; i < rotateFrom; i++)
            {
                nums2[index] = nums[i];
                index++;
            }

            return nums2;
        }

        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            var newArr = Rotate(nums, 3);

            foreach (var item in newArr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
