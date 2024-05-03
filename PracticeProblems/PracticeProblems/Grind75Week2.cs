using System.Diagnostics.Metrics;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace PracticeProblems
{
    internal class Grind75Week2
    {
        /* 278 - First Bad Version */
        public int FirstBadVersion(int n)
        {
            var left = 1;
            var right = n;

            while (left < right)
            {
                var mid = left + (right - left) / 2;
                if (IsBadVersion(mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        public bool IsBadVersion(int n)
        {
            return true;
        }

        /* 383 - Ransom Note */
        public bool CanConstruct(string ransomNote, string magazine)
        {
            //Dictionary<char, int> availableLetters = new Dictionary<char, int>();

            if (ransomNote.Length > magazine.Length)
            {
                return false;
            }

            for(int i = 0; i < ransomNote.Length; i++)
            {
                var thisChar = ransomNote[i];
                var index = magazine.IndexOf(thisChar);
                if (index >= 0)
                {
                    magazine = magazine.Remove(index, 1);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /* 70 - Climbing Stairs */
        public int ClimbStairs(int n)
        {
            if (n == 1) return 1;
            var current = 2;
            var prev1 = 1;
            var prev2 = 2;

            for (int i = 3; i <= n; i++)
            {
                current = prev1 + prev2;
                prev1 = prev2;
                prev2 = current;
            }
            return current;
        }

        /* 409 - Longest Palindrome */
        public int LongestPalindrome(string s)
        {
            Dictionary<char, int> characterOccurrences = new Dictionary<char, int>();

            for(int i = 0; i < s.Length; i++)
            {
                if (!characterOccurrences.ContainsKey(s[i]))
                {
                    characterOccurrences[s[i]] = 1;
                }
                else
                {
                    characterOccurrences[s[i]]++;
                }
            }
            var doubles = 0;
            var extra = false;
            foreach(var kvp in characterOccurrences)
            {
                doubles += kvp.Value / 2;
                if (!extra && kvp.Value % 2 > 0)
                {
                    extra = true;
                }
            }
            return extra ? doubles * 2 + 1 : doubles * 2;
        }

        /* 206 - Reverse Linked List */
        public ListNode ReverseList(ListNode head)
        {
            if (head is null)
            {
                return null;
            }
            var prev = head;
            var current = head.next;
            head.next = null;

            while (current != null)
            {
                var temp = current.next;
                current.next = prev;
                prev = current;
                current = temp;
            }

            return prev;
        }

        /* 169 - Majority Element */
        public int MajorityElement(int[] nums)
        {
            Dictionary<int, int> occurrences = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                if (occurrences.ContainsKey(num))
                {
                    occurrences[num]++;
                }
                else
                {
                    occurrences[num] = 1;
                }
            }

            return occurrences.MaxBy(x => x.Value).Key;
        }

        /* 67 - Add Binary */
        public string AddBinary(string a, string b)
        {
            var aRev = a.Reverse().ToArray();
            var bRev = b.Reverse().ToArray();
            var max = Math.Max(aRev.Length, bRev.Length);
            var sb = new StringBuilder();
            var carry = 0;
        
            for(int i = 0; i < max; i++)
            {
                var aVal = 0;
                var bVal = 0;
                if (aRev.Length > i)
                {
                    aVal = Int32.Parse(aRev[i].ToString());
                }
                if (bRev.Length > i)
                {
                    bVal = Int32.Parse(bRev[i].ToString());
                }
                var thisVal = (aVal + bVal + carry) % 2;
                carry = (aVal + bVal + carry) / 2;
                sb.Append(thisVal);
            }
            if (carry == 1)
            {
                sb.Append('1');
            }
            var resultStr = new string(sb.ToString().Reverse().ToArray());
            return resultStr;
        }

        /* 543 - Diameter of Binary Tree */
        private int diameter = 0;

        public int DiameterOfBinaryTree(TreeNode root)
        {
            GetDiameterHeight(root);
            return diameter - 2;
        }

        public int GetDiameterHeight(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }
            int left = 1 + GetDiameterHeight(node.left);
            int right = 1 + GetDiameterHeight(node.right);
            if (left + right > diameter)
            {
                diameter = left + right;
            }
            return Math.Max(left, right);
        }

        /* 876 - Middle of the Linked List */
        public ListNode MiddleNode(ListNode head)
        {
            var slowTracker = head;
            var fastTracker = head;
            var length = 0;

            while (fastTracker.next != null && fastTracker.next.next != null)
            {
                length++;
                slowTracker = slowTracker.next;
                fastTracker = fastTracker.next.next;
            }
            if (fastTracker.next != null)
            {
                slowTracker = slowTracker.next;
            }

            return slowTracker;
        }

        /* 104 - Maximum Depth of Binary Tree */
        public int MaxDepth(TreeNode node)
        {
            return GetHeight(node);
        }

        public int GetHeight(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }
            var left = 1 + GetHeight(node.left);
            var right = 1 + GetHeight(node.right);
            return Math.Max(left, right);
        }

        /* 217 - Contains Duplicate */
        public bool ContainsDuplicate(int[] nums)
        {
            var matches = new HashSet<int>();

            foreach (int num in nums)
            {
                if (!matches.Contains(num))
                {
                    matches.Add(num);
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        /* 53 - Maximum Subarray */
        public int MaxSubArray(int[] nums)
        {
            var maxSum = -1;
            var currentSum = 0;

            for(int i = 0; i <  nums.Length; i++)
            {
                if (nums[i] > 0){
                    currentSum += nums[i];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
                else
                {
                    if (currentSum + nums[i] <= 0)
                    {
                        currentSum = 0;
                    }
                    else
                    {
                        currentSum += nums[i];
                    }
                }
            }

            if (maxSum == -1)
            {
                maxSum = nums.Max();
            }

            return maxSum;
        }
    }
}
