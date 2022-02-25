using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    internal class LeetSortList_148
    {
        /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
        public ListNode SortList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode middle = GetMiddle(head);
            ListNode left = head;
            ListNode right = middle.next;
            middle.next = null;

            return Merge(SortList(left), SortList(right));
        }

        public ListNode Merge(ListNode head1, ListNode head2)
        {
            ListNode tracker1 = head1;
            ListNode tracker2 = head2;

            ListNode newListHead = new ListNode();
            ListNode current = newListHead;
            while (tracker1 != null && tracker2 != null)
            {
                if (tracker1.val < tracker2.val)
                {
                    current.next = tracker1;
                    tracker1 = tracker1.next;
                }
                else
                {
                    current.next = tracker2;
                    tracker2 = tracker2.next;
                }
                current = current.next;
            }
            current.next = tracker1 == null ? tracker2 : tracker1;

            return newListHead.next;
        }

        public ListNode GetMiddle(ListNode head)
        {
            if (head == null)
            {
                return head;
            }
            ListNode eventuallyMid = head;
            ListNode fastTracker = head;

            while (fastTracker.next != null && fastTracker.next.next != null)
            {
                eventuallyMid = eventuallyMid.next;
                fastTracker = fastTracker.next.next;
            }

            return eventuallyMid;
        }
    }
}
