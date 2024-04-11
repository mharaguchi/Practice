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
                if (leftHeight <=  rightHeight)
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
    }
}
