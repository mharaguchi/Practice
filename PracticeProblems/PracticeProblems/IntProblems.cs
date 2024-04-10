using System.Text;

namespace PracticeProblems
{
    internal class IntProblems
    {
        /* 12 - Integer to Roman */
        public string IntToRoman(int num)
        {
            var numStr = num.ToString();

            //var numCharArray = numStr.ToCharArray();
            //Array.Reverse(numCharArray);
            //var reverseNumStr = new string(numCharArray);

            var sb = new StringBuilder();

            for(int i = 0; i < numStr.Length; i++)
            {
                var distFromEnd = numStr.Length - i - 1;
                var thisNum = Int32.Parse(numStr[i].ToString());
                if (distFromEnd == 3)
                {
                    for (int j = 0; j < thisNum; j++) {
                        sb.Append("M");
                    }
                }
                if (distFromEnd == 2)
                {
                    if (thisNum == 4)
                    {
                        sb.Append("CD");
                    }
                    else if (thisNum == 9)
                    {
                        sb.Append("CM");
                    }
                    else
                    {
                        if (thisNum >= 5) //use D
                        {
                            sb.Append("D");
                            for (int j = 0; j < thisNum - 5; j++)
                            {
                                sb.Append("C");
                            }
                        }
                        else //no D, just Cs
                        {
                            for (int j = 0; j < thisNum; j++)
                            {
                                sb.Append("C");
                            }
                        }
                    }
                }
                if (distFromEnd == 1)
                {
                    if (thisNum == 4)
                    {
                        sb.Append("XL");
                    }
                    else if (thisNum == 9)
                    {
                        sb.Append("XC");
                    }
                    else
                    {
                        if (thisNum >= 5) //use L
                        {
                            sb.Append("L");
                            for (int j = 0; j < thisNum - 5; j++)
                            {
                                sb.Append("X");
                            }
                        }
                        else //no D, just X
                        {
                            for (int j = 0; j < thisNum; j++)
                            {
                                sb.Append("X");
                            }
                        }
                    }
                }
                if (distFromEnd == 0)
                {
                    if (thisNum == 4)
                    {
                        sb.Append("IV");
                    }
                    else if (thisNum == 9)
                    {
                        sb.Append("IX");
                    }
                    else
                    {
                        if (thisNum >= 5) //use V
                        {
                            sb.Append("V");
                            for (int j = 0; j < thisNum - 5; j++)
                            {
                                sb.Append("I");
                            }
                        }
                        else //no V, just I
                        {
                            for (int j = 0; j < thisNum; j++)
                            {
                                sb.Append("I");
                            }
                        }
                    }
                }
            }

            return sb.ToString();
        }
    }
}
