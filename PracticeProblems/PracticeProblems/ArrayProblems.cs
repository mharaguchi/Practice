﻿namespace PracticeProblems
{
    internal class ArrayProblems
    {
        /* 11 - Container With Most Water */
        public int MaxArea(int[] height)
        {
            var maxArea = 0;
            var left = 0;
            var right = height.Length - 1;

            while (left < right)
            {
                var leftHeight = height[left];
                var rightHeight = height[right];
                var smaller = leftHeight < rightHeight ? leftHeight : rightHeight;
                var thisArea = (right - left) * smaller;
                if (maxArea < thisArea)
                {
                    maxArea = thisArea;
                }
                if (leftHeight <= rightHeight)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return maxArea;
        }

        /* 15 - 3Sum */
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var matches = new List<IList<int>>();

            Array.Sort(nums);
            var current = 0;
            int left, right;

            while (nums[current] <= 0 && current < nums.Length - 2)
            {
                left = current + 1;
                right = nums.Length - 1;

                var target = nums[current] * -1;

                while (left < right)
                {
                    if (nums[current] + nums[left] + nums[right] == 0)
                    {
                        matches.Add(new List<int> { nums[current], nums[left], nums[right] });
                        int prevLeft = nums[left];
                        while (left < right && nums[left] == prevLeft)
                        {
                            left++;
                        }
                        int prevRight = nums[right];
                        while (left < right && nums[right] == prevRight)
                        {
                            right--;
                        }
                    }
                    else if (nums[left] + nums[right] < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
                int prevNum = nums[current];
                while (current < nums.Length - 2 && nums[current] == prevNum)
                {
                    current++;
                }
            }
            return matches;
        }

        /* 46 - Permutations */
        public IList<IList<int>> Permute(int[] nums)
        {
            var permutations = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                var used = new HashSet<int>();
                var thisPermutation = new List<int>
                {
                    nums[i]
                };
                used.Add(i);
                BacktrackPermutations(permutations, thisPermutation, nums, used);
            }

            return permutations;
        }

        public void BacktrackPermutations(List<IList<int>> permutations, List<int> thisPermutation, int[] nums, HashSet<int> used)
        {
            if (thisPermutation.Count == nums.Length)
            {
                permutations.Add(new List<int>(thisPermutation));
                return;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (!used.Contains(i))
                {
                    thisPermutation.Add(nums[i]);
                    used.Add(i);
                    BacktrackPermutations(permutations, thisPermutation, nums, used);
                    thisPermutation.RemoveAt(thisPermutation.Count - 1);
                    used.Remove(i);
                }
            }
        }

        /* 120 - Triangle */
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            var lastRow = triangle[triangle.Count - 1];
            for(int i = 0; i < triangle.Count - 2; i--)
            {
                for(int j = 0; j < triangle[i].Count; j++)
                {
                    lastRow[j] = Math.Min(lastRow[j], lastRow[j + 1]) + triangle[i][j];
                }
            }
            
            return lastRow[0];
        }
    }
}
