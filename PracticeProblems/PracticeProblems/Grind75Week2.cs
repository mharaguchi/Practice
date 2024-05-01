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
    }
}
