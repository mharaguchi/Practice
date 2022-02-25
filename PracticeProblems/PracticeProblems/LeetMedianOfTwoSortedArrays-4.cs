using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    public class LeetMedianOfTwoSortedArrays_4
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var total = nums1.Length + nums2.Length;

            if (total == 1)
            {
                if (nums1.Length == 1)
                {
                    return nums1[0];
                }
                else
                {
                    return nums2[0];
                }
            }

            var nums1tracker = 0;
            var nums2tracker = 0;

            if (total % 2 == 1)
            { //odd, return the middle value
                var middle = total / 2;
                if (nums1.Length == 0)
                {
                    return nums2[middle];
                }
                if (nums2.Length == 0)
                {
                    return nums1[middle];
                }

                for (int i = 0; i < middle; i++)
                {
                    if (nums2tracker == nums2.Length || nums1tracker < nums1.Length && nums1[nums1tracker] < nums2[nums2tracker])
                    {
                        nums1tracker++;
                    }
                    else
                    {
                        nums2tracker++;
                    }
                }
                if (nums2tracker == nums2.Length || nums1tracker < nums1.Length && nums1[nums1tracker] < nums2[nums2tracker])
                {
                    return nums1[nums1tracker];
                }
                else
                {
                    return nums2[nums2tracker];
                }
            }
            else
            { //even, return the average of the middle 2
                var middle = total / 2 - 1;
                var middleVal1 = 0;
                var middleVal2 = 0;

                if (nums1.Length == 0)
                {
                    return ((double)nums2[middle] + nums2[middle + 1]) / 2;
                }
                if (nums2.Length == 0)
                {
                    return ((double)nums1[middle] + nums1[middle + 1]) / 2;
                }

                for (int i = 0; i < middle; i++)
                {
                    if (nums2tracker == nums2.Length || nums1tracker < nums1.Length && nums1[nums1tracker] < nums2[nums2tracker])
                    {
                        nums1tracker++;
                    }
                    else
                    {
                        nums2tracker++;
                    }
                }
                if (nums2tracker == nums2.Length || nums1tracker < nums1.Length && nums1[nums1tracker] < nums2[nums2tracker])
                {
                    middleVal1 = nums1[nums1tracker];
                    nums1tracker++;
                }
                else
                {
                    middleVal1 = nums2[nums2tracker];
                    nums2tracker++;
                }
                if (nums2tracker == nums2.Length || nums1tracker < nums1.Length && nums1[nums1tracker] < nums2[nums2tracker])
                {
                    middleVal2 = nums1[nums1tracker];
                }
                else
                {
                    middleVal2 = nums2[nums2tracker];
                }
                return ((double)middleVal1 + middleVal2) / 2;
            }
        }
    }
}
