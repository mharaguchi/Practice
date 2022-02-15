using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    internal class CtCIStringsProblems
    {
        internal bool HasUniqueCharacters(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var newCharacter = input[i];
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (newCharacter == input[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        internal bool IsPermutation(string inputString1, string inputString2)
        {
            if (inputString1.Length != inputString2.Length)
            {
                return false;
            }

            var matchedString2Indexes = new List<int>();
            for (int i = 0; i < inputString1.Length; i++)
            {
                var matchThisCharacter = inputString1[i];
                for(int j = 0; j < inputString2.Length; j++)
                {
                    if (matchThisCharacter == inputString2[j] && !matchedString2Indexes.Contains(j))
                    {
                        matchedString2Indexes.Add(j);
                        break;
                    }
                    if (j == inputString2.Length - 1)
                    {
                        return false;
                    }
                }
            }

            return matchedString2Indexes.Count == inputString1.Length;
        }

        internal bool IsPalindromePermutation(string input)
        {
            var characterDictionary = new Dictionary<char, int>();
            for (int i = 0;i < input.Length; i++)
            {
                var thisChar = Char.ToLower(input[i]);
                if (!Char.IsLetter(thisChar))
                {
                    continue;
                }
                characterDictionary[thisChar] = characterDictionary.ContainsKey(thisChar) ? ++characterDictionary[thisChar] : 1;
            }
            var oddNumberOccurrences = 0;
            foreach(var kvp in characterDictionary)
            {
                if (kvp.Value % 2 > 0)
                {
                    oddNumberOccurrences++;
                }
            }

            return oddNumberOccurrences <= 1;
        }

        internal bool IsOneAway(string inputString1, string inputString2)
        {
            var numFixesUsed = 0;
            const int numFixesAllowed = 1;

            if (Math.Abs(inputString1.Length - inputString2.Length) > 1)
            {
                return false;
            }

            if (inputString1.Length == inputString2.Length)
            {
                for(int i = 0; i < inputString1.Length; i++)
                {
                    if (inputString1[i] == inputString2[i])
                    {
                        continue;
                    }
                    else
                    {
                        if (numFixesUsed > 0)
                        {
                            return false;
                        }
                        else
                        {
                            numFixesUsed++;
                        }
                    }
                }
            }
            else if (inputString1.Length < inputString2.Length)
            {
                for(int i = 0; i < inputString2.Length; i++)
                {
                    if(i < inputString1.Length && inputString1[i] == inputString2[i])
                    {
                        continue;
                    }
                    else
                    {
                        inputString1.Insert(i, inputString2[i].ToString());
                        if (numFixesUsed > 0)
                        {
                            return false;
                        }
                        else
                        {
                            numFixesUsed++;
                        }
                    }
                }
            }
            else if (inputString1.Length > inputString2.Length)
            {
                for (int i = 0; i < inputString1.Length; i++)
                {
                    if (i < inputString2.Length && inputString1[i] == inputString2[i])
                    {
                        continue;
                    }
                    else
                    {
                        inputString2.Insert(i, inputString1[i].ToString());
                        if (numFixesUsed > 0)
                        {
                            return false;
                        }
                        else
                        {
                            numFixesUsed++;
                        }
                    }
                }
            }

            return numFixesUsed <= numFixesAllowed;
        }

        internal string CompressString(string inputString)
        {
            var compressedStringBuilder = new StringBuilder();
            var lastChar = '!';
            var count = 0;
            for(int i = 0; i < inputString.Length; i++)
            {
                var thisChar = inputString[i];
                if (i == 0)
                {
                    lastChar = thisChar;
                    count = 1;
                }
                else
                {
                    if (lastChar == thisChar)
                    {
                        count++;
                        if (i == inputString.Length - 1)
                        {
                            compressedStringBuilder.Append(lastChar + count.ToString());
                        }
                    }
                    else
                    {
                        compressedStringBuilder.Append(lastChar + count.ToString());
                        count = 1;
                        lastChar = thisChar;
                    }
                }
            }
            var compressedString = compressedStringBuilder.ToString();
            if (compressedString.Length > inputString.Length)
            {
                return inputString;
            }
            else
            {
                return compressedString;
            }
        }
    }
}
