using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class MyQueue
    {
        readonly Stack<int> stack1 = new Stack<int>();
        readonly Stack<int> stack2 = new Stack<int>();

        public MyQueue()
        {

        }

        public void Push(int x)
        {
            if (stack1.Count == 0)
            {
                stack1.Push(x);
            }
            else
            {
                while (stack1.Count > 0)
                {
                    var num = stack1.Pop();
                    stack2.Push(num);
                }
                stack1.Push(x);
                while (stack2.Count > 0)
                {
                    var num = stack2.Pop();
                    stack1.Push(num);
                }
            }
        }

        public int Pop()
        {
            return stack1.Pop();
        }

        public int Peek()
        {
            return stack1.Peek();
        }

        public bool Empty()
        {
            return !stack1.Any();
        }
    }
}
