using System;
using System.Collections.Generic;

namespace SingleNumber
{
    internal class Program
    {
        public static int SingleNumber(int[] nums)
        {
            var dictionory = new Dictionary<int, bool>();
            int result = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (dictionory.ContainsKey(nums[i]))
                {
                    dictionory[nums[i]] = true;
                }
                else dictionory.Add(nums[i], false);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (dictionory[nums[i]] == false)
                {
                    result = nums[i];
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            int[] nums = new int[] { 2, 2, 1 };
            int result = SingleNumber(nums);

            Console.WriteLine(result);
        }
    }
}
