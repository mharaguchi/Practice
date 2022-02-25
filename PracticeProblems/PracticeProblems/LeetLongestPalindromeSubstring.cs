using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    public class LeetLongestPalindromeSubstring
    {
        public string LongestPalindrome(string s)
        {
            var longestPalindrome = "";

            for (int i = 0; i < s.Length; i++)
            {
                if (s.Length - i < longestPalindrome.Length)
                {
                    continue;
                }
                string current = "";
                for (int j = i; j < s.Length; j++)
                {
                    current = current + s[j];

                    if (current.Length * 2 - 1 + i > s.Length)
                    { //last char pivot is past end of s
                        break;
                    }
                    if (current.Length * 2 - 1 > longestPalindrome.Length) //long enough to be a new candidate
                    {
                        var middlePally = GetMiddlePally(current, s, i);
                        if (!string.IsNullOrWhiteSpace(middlePally))
                        { //check for last char pivot palindrome
                            longestPalindrome = middlePally;
                        }
                    }

                    if (current.Length * 2 + i > s.Length)
                    { //double copy pally is past end of s
                        break;
                    }
                    if (current.Length * 2 <= longestPalindrome.Length)
                    { //not long enough to be a new candidate
                        continue;
                    }
                    var doublePally = GetDoublePally(current, s, i);
                    if (!string.IsNullOrWhiteSpace(doublePally))
                    {
                        longestPalindrome = doublePally;
                    }
                }
            }
            return longestPalindrome;
        }

        public string GetMiddlePally(string current, string s, int startIndex)
        {
            var diff = 2;
            var stillPally = true;
            var middlePally = current;
            for (int k = current.Length - 2; k >= 0; k--)
            {
                if (s[k + diff + startIndex] != current[k])
                {
                    stillPally = false;
                    break;
                }
                else
                {
                    middlePally += s[k + diff + startIndex];
                    diff+=2;
                }
            }

            return stillPally ? middlePally : "";
        }

        public string GetDoublePally(string current, string s, int startIndex)
        {
            var diff = 1;
            var stillPally = true;
            var doublePally = current;
            for (int k = current.Length - 1; k >= 0; k--)
            {
                if (s[k + diff + startIndex] != current[k])
                {
                    stillPally = false;
                    break;
                }
                else
                {
                    doublePally += s[k + diff + startIndex];
                    diff+=2;
                }
            }

            return stillPally ? doublePally : "";
        }

    }
}
