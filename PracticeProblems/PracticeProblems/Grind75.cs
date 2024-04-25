using System.Diagnostics.Metrics;
using System.Text;
using System.Text.RegularExpressions;

namespace PracticeProblems
{
    internal class GrindProblems
    {
        /* 21 - Merge Two Sorted Lists */
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            var list1Tracker = list1;
            var list2Tracker = list2;
            ListNode preHead = new ListNode();
            ListNode current = null;

            if (list1Tracker == null && list2Tracker == null)
            {
                return null;
            }

            while (list1Tracker != null && list2Tracker != null)
            {
                if (list1Tracker.val < list2Tracker.val)
                {
                    if (current != null)
                    {
                        current.next = list1Tracker;
                    }
                    current = list1Tracker;
                    list1Tracker = list1Tracker.next;
                }
                else
                {
                    if (current != null)
                    {
                        current.next = list2Tracker;
                    }
                    current = list2Tracker;
                    list2Tracker = list2Tracker.next;
                }
                if (preHead.next == null)
                {
                    preHead.next = current;
                }
            }

            if (list1Tracker == null)
            {
                if (current == null)
                {
                    preHead.next = list2Tracker;
                }
                else
                {
                    current.next = list2Tracker;
                }
            }
            else
            {
                if (current == null) { preHead.next = list1Tracker; }
                else
                {
                    current.next = list1Tracker;
                }
            }

            return preHead.next;
        }


        /* 121 - Best Time To Buy and Sell Stock */
        public int MaxProfit(int[] prices)
        {
            var curMin = 0;
            var curMaxDiff = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                var thisVal = prices[i];
                if (i == 0)
                {
                    curMin = thisVal;
                }
                var diff = thisVal - curMin;
                if (diff > curMaxDiff && diff > 0)
                {
                    curMaxDiff = diff;
                }
                if (thisVal < curMin)
                {
                    curMin = thisVal;
                }
            }

            return curMaxDiff;
        }

        /* 125 - Valid Palindrome */
        public bool IsPalindrome(string s)
        {
            var lowerString = s.ToLower();
            var cleanStringBuilder = new StringBuilder();

            for(int i = 0; i < lowerString.Length; i++)
            {
                if ((lowerString[i] >= 48 && lowerString[i] <= 57) || (lowerString[i] >= 97 && lowerString[i] <= 122))
                {
                    cleanStringBuilder.Append(lowerString[i]);
                }
            }

            var cleanString = cleanStringBuilder.ToString();

            if (cleanString.Length == 0)
            {
                return true;
            }

            var head = 0;
            var tail = cleanString.Length - 1;
            while (head <= tail)
            {
                if (cleanString[head] != cleanString[tail])
                {
                    return false;
                }
                head++;
                tail--;
            }

            return true;
        }


    }
}
