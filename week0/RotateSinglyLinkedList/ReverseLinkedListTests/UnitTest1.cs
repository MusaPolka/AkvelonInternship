using RotateSinglyLinkedList;
using System;
using Xunit;

namespace ReverseLinkedListTests
{
    public class UnitTest1
    {
        [Fact]
        public void ReverseLinear_ShouldProperlyReverse()
        {
            //Initial data
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);

            //Expected data
            ListNode expected = new ListNode(3);
            expected.next = new ListNode(2);
            expected.next.next = new ListNode(1);

            //Actual data
            var actual = head.ReverseLinear(head);
            

            Assert.Equal(expected.val, actual.val);
            Assert.Equal(expected.next.val, actual.next.val);
            Assert.Equal(expected.next.next.val, actual.next.next.val);
        }

        [Fact]
        public void ReverseUnsingStack_ShouldProperlyReverse()
        {
            //Initial data
            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);

            //Expected data
            ListNode expected = new ListNode(3);
            expected.next = new ListNode(2);
            expected.next.next = new ListNode(1);

            //Actual data
            var actual = head.ReverseUsingStack(head);


            Assert.Equal(expected.val, actual.val);
            Assert.Equal(expected.next.val, actual.next.val);
            Assert.Equal(expected.next.next.val, actual.next.next.val);
        }
    }
}
