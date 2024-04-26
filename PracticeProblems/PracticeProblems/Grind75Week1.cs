using System.Diagnostics.Metrics;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace PracticeProblems
{
    internal class Grind75Week1
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

            for (int i = 0; i < lowerString.Length; i++)
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

        /* 226 - Invert Binary Tree */
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return root;
            }
            if (root.left == null && root.right == null)
            {
                return root;
            }
            else if (root.left == null && root.right != null)
            {
                root.left = root.right;
                root.right = null;
            }
            else if (root.right == null && root.left != null)
            {
                root.right = root.left;
                root.left = null;
            }
            else
            {
                TreeNode temp = root.left;
                root.left = root.right;
                root.right = temp;
            }
            if (root.left != null)
            {
                InvertTree(root.left);
            }
            if (root.right != null)
            {
                InvertTree(root.right);
            }
            return root;
        }

        /* 242 - Valid Anagram */
        public bool IsAnagram(string s, string t)
        {
            var sCount = new Dictionary<char, int>();
            var tCount = new Dictionary<char, int>();
            if (s.Length != t.Length)
            {
                return false;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (sCount.ContainsKey(s[i]))
                {
                    sCount[s[i]] = sCount[s[i]] + 1;
                }
                else
                {
                    sCount[s[i]] = 1;
                }
                if (tCount.ContainsKey(t[i]))
                {
                    tCount[t[i]] = tCount[t[i]] + 1;
                }
                else
                {
                    tCount[t[i]] = 1;
                }
            }
            foreach (var sCountKvp in sCount)
            {
                if (!tCount.ContainsKey(sCountKvp.Key))
                {
                    return false;
                }
                if (sCountKvp.Value != tCount[sCountKvp.Key])
                {
                    return false;
                }
            }

            return true;
        }

        /* 704 - Binary Search */
        public int Search(int[] nums, int target)
        {
            if (nums.Length == 0)
            {
                return -1;
            }

            var start = 0;
            var end = nums.Length - 1;

            while (end - start > 1)
            {
                var tracker = (end + start) / 2;
                if (nums[tracker] == target)
                {
                    return tracker;
                }
                if (nums[tracker] < target)
                {
                    start = tracker + 1;
                    continue;
                }
                if (nums[tracker] > target)
                {
                    end = tracker - 1;
                    continue;
                }
            }
            if (nums[start] == target)
            {
                return start;
            }
            if (nums[end] == target)
            {
                return end;
            }
            return -1;
        }

        /* 733 - Flood Fill */
        public int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            var squareStack = new Stack<(int, int)>();
            squareStack.Push((sr, sc));

            var traversed = new HashSet<(int, int)>
        {
            (sr, sc)
        };

            var changeList = new List<(int, int)>();
            var matchColor = image[sr][sc];

            while (squareStack.Count > 0)
            {
                var thisSquare = squareStack.Pop();
                if (image[thisSquare.Item1][thisSquare.Item2] == matchColor)
                {
                    changeList.Add(thisSquare);
                }

                //Add squares to stack
                if (thisSquare.Item1 - 1 >= 0)
                {
                    var leftSquare = (thisSquare.Item1 - 1, thisSquare.Item2);
                    if (!traversed.Contains(leftSquare)) //left
                    {
                        if (image[leftSquare.Item1][leftSquare.Item2] == matchColor)
                        {
                            squareStack.Push(leftSquare);
                        }
                        traversed.Add(leftSquare);
                    }
                }
                if (thisSquare.Item1 + 1 < image.Length)
                {
                    var rightSquare = (thisSquare.Item1 + 1, thisSquare.Item2);
                    if (!traversed.Contains(rightSquare)) //right
                    {
                        if (image[rightSquare.Item1][rightSquare.Item2] == matchColor)
                        {
                            squareStack.Push(rightSquare);
                        }
                        traversed.Add(rightSquare);
                    }
                }
                if (thisSquare.Item2 - 1 >= 0)
                {
                    var upSquare = (thisSquare.Item1, thisSquare.Item2 - 1);
                    if (!traversed.Contains(upSquare)) //up
                    {
                        if (image[upSquare.Item1][upSquare.Item2] == matchColor)
                        {
                            squareStack.Push(upSquare);
                        }
                        traversed.Add(upSquare);
                    }
                }
                if (thisSquare.Item2 + 1 < image[0].Length)
                {
                    var downSquare = (thisSquare.Item1, thisSquare.Item2 + 1);
                    if (!traversed.Contains(downSquare)) //down
                    {
                        if (image[downSquare.Item1][downSquare.Item2] == matchColor)
                        {
                            squareStack.Push(downSquare);
                        }
                        traversed.Add(downSquare);
                    }
                }
            }

            foreach (var square in changeList)
            {
                image[square.Item1][square.Item2] = color;
            }

            return image;
        }

        /* 235 - Lowest Common Ancestor of BST */
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            var current = root;
            while ((p.val < current.val && q.val < current.val) || (p.val > current.val && q.val > current.val)){
                if (p.val < current.val)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
            }

            return current;
        }
    }
}
