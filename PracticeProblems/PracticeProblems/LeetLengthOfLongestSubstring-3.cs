using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    internal class LeetLengthOfLongestSubstring_3
    {
        public int LengthOfLongestSubstring(string s)
        {
            var longest = "";
            if (s.Length == 1)
            {
                return 1;
            }

            for (int i = 0; i < s.Length; i++)
            {
                var dict = new Dictionary<char, bool>();
                var substring = s[i].ToString();
                dict[s[i]] = true;
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (dict.ContainsKey(s[j]))
                    {
                        if (substring.Length > longest.Length)
                        {
                            longest = substring;
                        }
                        break;
                    }
                    else
                    {
                        substring += s[j];
                        dict[s[j]] = true;
                        if (j == s.Length - 1 && substring.Length > longest.Length)
                        {
                            longest = substring;
                        }
                    }
                }
            }

            return longest.Length;
        }
    }
}
