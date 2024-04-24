using System.Diagnostics.Metrics;

namespace PracticeProblems
{
    internal class GrindProblems
    {

        public void Run()
        {

        }

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
    }
}
