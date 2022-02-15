using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    internal class LeetSingleNumber_136
    {
        public int SingleNumber(int[] nums)
        {
            var dict = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num] = dict[num] + 1;
                }
                else
                {
                    dict[num] = 1;
                }
            }
            foreach (var kvp in dict)
            {
                if (kvp.Value == 1)
                {
                    return kvp.Key;
                }
            }
            return -1;
        }
    }
}
