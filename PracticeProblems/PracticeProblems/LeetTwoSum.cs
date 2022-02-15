namespace PracticeProblems
{
    public class LeetTwoSum
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]].Add(i);
                }
                else
                {
                    dict[nums[i]] = new List<int> { i };
                }
            }
            for (int i = 0; i < nums.Length; i++)
            {
                var thisNum = nums[i];
                var thisPos = i;
                var neededNum = target - thisNum;
                if (!dict.ContainsKey(neededNum))
                {
                    continue;
                }
                if (neededNum == thisNum)
                {
                    if (dict[neededNum].Count > 1)
                    {
                        return dict[neededNum].ToArray();
                    }
                }
                else
                {
                    if (dict[neededNum].Count > 0)
                    {
                        return new int[] { thisPos, dict[neededNum][0] };
                    }
                }
            }
            throw new Exception("Could not find solution");
        }
    }
}
