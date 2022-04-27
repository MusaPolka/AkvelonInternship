using System;

namespace DemoTask
{
    internal class Program
    {
        static int[] ReplaceZeros(int[] nums)
        {
            int count = 1;

            int index = nums.Length - 1;
            while (index > 0 && nums[index] == 0)
            {
                count++;
                index--;
            }

            for (int i = 0; i < nums.Length - count; i++)
            {
                if (nums[i] == 0)
                {
                    var temp = nums[nums.Length - count];
                    nums[nums.Length - count] = nums[i];
                    nums[i] = temp;

                    while (index> 0 && nums[index] == 0)
                    {
                        count++;
                        index--;
                    }
                }
                
            }

            return nums;
        }
        static void Main(string[] args)
        {
            
            int[] nums = new int[] { 1, 2, 0, 3, 0, 3, 1 };
            ReplaceZeros(nums);

        }
    }
}
