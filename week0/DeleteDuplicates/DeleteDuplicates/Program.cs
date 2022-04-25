using System;
using System.Collections.Generic;

namespace DeleteDuplicates
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    internal class Program
    {
        public static ListNode DeleteDuplicatesWithoutRecursion(ListNode head)
        {
            ListNode result = head;

            while (result != null)
            {
                if (result.next == null)
                {
                    break;
                }

                if (result.val == result.next.val)
                {
                    result.next = result.next.next;
                }
                else
                {
                    result = result.next;
                }
            }
            return head;
        }
        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            head.next = DeleteDuplicates(head.next);

            if (head.val == head.next.val)
            {
                return head.next;
            }

            return head;
        }

        static void Main(string[] args)
        {
            ListNode listNode = new ListNode();
            listNode.val = 1;
            ListNode listNode2 = new ListNode();
            listNode2.val = 1;
            ListNode listNode3 = new ListNode();
            listNode3.val = 2;

            listNode.next = listNode2;
            listNode2.next = listNode3;
            listNode3.next = null;


            //var list = DeleteDuplicates(listNode);
            var list2 = DeleteDuplicatesWithoutRecursion(listNode);
        }
    }
}
