using System;
using System.Collections;
using System.Collections.Generic;

namespace RotateSinglyLinkedList
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
        public ListNode ReverseLinear(ListNode head)
        {
            ListNode prevNode = null;

            while (head != null)
            {
                ListNode nextNode = head.next;
                head.next = prevNode;
                prevNode = head;
                head = nextNode;
            }

            return prevNode;
        }

        public ListNode ReverseUsingStack(ListNode head)
        {
            Stack<ListNode> stack = new Stack<ListNode>();
            stack.Push(head);

            while (head.next != null)
            {
                stack.Push(head.next);
                head = head.next;
            }

            var resultNode = new ListNode();
            var temp = resultNode;

            while (stack.Count > 0)
            {
                temp.next = stack.Pop();
                temp = temp.next;
            }

            temp.next = null;
            return resultNode.next;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);

            var reversedLinkedList = head.ReverseUsingStack(head);

            while (reversedLinkedList != null)
            {
                Console.WriteLine(reversedLinkedList.val);
                reversedLinkedList = reversedLinkedList.next;
            }
        }
    }
}
