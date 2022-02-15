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

    internal class LeetAddTwoNumbers_2
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var tracker1 = l1;
            var tracker2 = l2;
            ListNode? result = null;
            ListNode? resultTracker = null;
            var carryover = 0;

            while (tracker1 != null || tracker2 != null || carryover > 0)
            {
                var thisDigit1 = tracker1 != null ? tracker1.val : 0;
                var thisDigit2 = tracker2 != null ? tracker2.val : 0;
                var total = thisDigit1 + thisDigit2 + carryover;

                var thisResultNode = new ListNode();
                thisResultNode.val = total % 10;
                if (result == null)
                {
                    result = thisResultNode;
                    resultTracker = result;
                }
                else
                {
                    resultTracker.next = thisResultNode;
                    resultTracker = thisResultNode;
                }
                carryover = total / 10;

                tracker1 = tracker1?.next;
                tracker2 = tracker2?.next;
            }

            return result;
        }
    }
}
