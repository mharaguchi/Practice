using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    internal class LeetAnswers
    {
        /* 13 - Roman to Integer */
        public int RomanToInt(string s)
        {
            var total = 0;
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case 'M':
                        total += 1000;
                        break;
                    case 'D':
                        if (i < s.Length - 1 && s[i + 1] == 'M')
                        {
                            total -= 500;
                        }
                        else
                        {
                            total += 500;
                        }
                        break;
                    case 'C':
                        if (i < s.Length - 1 && (s[i + 1] == 'D' || s[i + 1] == 'M'))
                        {
                            total -= 100;
                        }
                        else
                        {
                            total += 100;
                        }
                        break;
                    case 'L':
                        if (i < s.Length - 1 && s[i + 1] == 'C')
                        {
                            total -= 50;
                        }
                        else
                        {
                            total += 50;
                        }
                        break;
                    case 'X':
                        if (i < s.Length - 1 && (s[i + 1] == 'L' || s[i + 1] == 'C'))
                        {
                            total -= 10;
                        }
                        else
                        {
                            total += 10;
                        }
                        break;
                    case 'V':
                        if (i < s.Length - 1 && s[i + 1] == 'X')
                        {
                            total -= 5;
                        }
                        else
                        {
                            total += 5;
                        }
                        break;
                    case 'I':
                        if (i < s.Length - 1 && (s[i + 1] == 'V' || s[i + 1] == 'X'))
                        {
                            total -= 1;
                        }
                        else
                        {
                            total += 1;
                        }
                        break;
                    default: break;
                }
            }

            return total;
        }

        /* 392 - IsSubSequence */
        public bool IsSubsequence(string s, string t)
        {
            var subsequenceTracker = 0;

            if (s.Length == 0)
            {
                return true;
            }

            for (int i = 0; i < t.Length; i++)
            {
                if (s[subsequenceTracker] == t[i])
                {
                    subsequenceTracker++;
                    if (subsequenceTracker == s.Length)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
