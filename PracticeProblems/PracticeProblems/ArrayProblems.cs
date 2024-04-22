using System.Diagnostics.Metrics;

namespace PracticeProblems
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

        /* 16 - 3Sum Closest */
        public int ThreeSumClosest(int[] nums, int target)
        {
            int closest = Int32.MaxValue;
            Array.Sort(nums);

            var current = 0;
            int left, right;

            while (current < nums.Length - 2)
            {
                left = current + 1;
                right = nums.Length - 1;

                while (left < right)
                {
                    var thisTotal = nums[left] + nums[current] + nums[right];
                    if (thisTotal == target)
                    {
                        return target;
                    }

                    var diff = thisTotal - target;
                    if (Math.Abs(diff) < Math.Abs(closest - target))
                    {
                        closest = thisTotal;
                    }
                    else if (diff < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
                current++;
            }
            return closest;
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

        /* 55 - Jump Game */
        public bool CanJump(int[] nums)
        {
            var score = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                score--;
                if (score < 0)
                {
                    return false;
                }
                else
                {
                    if (nums[i] > score)
                    {
                        score = nums[i];
                    }
                }
            }
            return true;
        }

        /* 36 - Valid Sudoku */
        public bool IsValidSudoku(char[][] board)
        {
            for(int i = 0; i < 9; i++)
            {
                var usedRow = new HashSet<char>();
                var usedCol = new HashSet<char>();
                for (int j = 0; j < 9; j++) {
                    if (board[j][i] != '.') //check rows
                    {
                        if (usedRow.Contains(board[j][i]))
                        {
                            return false;
                        }
                        usedRow.Add(board[j][i]);
                    }
                    if (board[i][j] != '.') //check cols
                    {
                        if (usedCol.Contains(board[i][j]))
                        {
                            return false;
                        }
                        usedCol.Add(board[i][j]);
                    }
                }
            }

            for (int i = 0; i < 9; i++) //check squares
            {
                var used = new HashSet<char>();
                var startX = (i % 3) * 3;
                var startY = (i / 3) * 3;
                for (int j = 0; j < 9; j++)
                {
                    var x = startX + (j % 3);
                    var y = (j / 3) + startY;
                    if (board[y][x] != '.')
                    {
                        if (used.Contains(board[y][x]))
                        {
                            return false;
                        }
                        used.Add(board[y][x]);
                    }
                }
            }

            return true;
        }

        /* 322 - Coin Change */
        //public int CoinChange(int[] coins, int amount)
        //{
        //    if (amount == 0)
        //    {
        //        return 0;
        //    }
        //    Array.Sort(coins, (a, b) => b.CompareTo(a));
        //    var result = BacktrackChange(coins, 0, 0, amount, Int32.MaxValue);
        //    return result < Int32.MaxValue ? result : -1;
        //}

        //public int BacktrackChange(int[] sortedCoins, int numCoins, int index, int target, int currentLow)
        //{
        //    var low = currentLow;
        //    for(int i = target / sortedCoins[index]; i >= 0; i--)
        //    {
        //        var newNumCoins = numCoins + i;
        //        var diff = target - sortedCoins[index] * i;
        //        if (diff == 0)
        //        {
        //            return newNumCoins;
        //        }
        //        else
        //        {
        //            if (index + 1 < sortedCoins.Length)
        //            {
        //                var result = BacktrackChange(sortedCoins, newNumCoins, index + 1, diff, low);
        //                if (result < low)
        //                {
        //                    low = result;
        //                }
        //            }
        //        }
        //    }
        //    return low;
        //}

        public int CoinChange(int[] coins, int amount)
        {
            var minCoins = new int[amount + 1];
            Array.Fill<int>(minCoins, Int32.MaxValue);
            minCoins[0] = 0;

            for(int i = 0; i <= amount; i++)
            {
                for (int j = 0; j < coins.Length; j++)
                {
                    var currentMin = minCoins[i]; //Could be previous coin's minimum
                    var previousDPIndex = i - coins[j];
                    if (previousDPIndex < 0)
                    {
                        continue;
                    }
                    if (minCoins[previousDPIndex] == Int32.MaxValue) { continue; }
                    var thisCoinMin = minCoins[i - coins[j]] + 1;
                    minCoins[i] = currentMin < thisCoinMin ? currentMin : thisCoinMin;
                }
            }

            return minCoins[amount] == Int32.MaxValue ? -1 : minCoins[amount];
        }
    }
}
