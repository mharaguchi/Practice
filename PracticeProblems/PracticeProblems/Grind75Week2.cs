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
    }
}
