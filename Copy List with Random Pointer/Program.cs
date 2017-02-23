using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copy_List_with_Random_Pointer
{
    class Program
    {
        static void Main(string[] args)
        {
            var head = new RandomListNode(1);
            var node2 = new RandomListNode(2);
            var node3 = new RandomListNode(3);
            var node4 = new RandomListNode(4);

            head.next = node2;
            head.random = node3;

            node2.next = node3;
            node2.random = head;

            node3.next = node4;
            node3.random = node4;

            node4.next = null;
            node4.random = node2;


            var headNode = CopyRandomList(head);
            while (headNode != null)
            {
                Console.WriteLine(headNode.label);
                headNode = headNode.next;
            }

        }

        public static RandomListNode CopyRandomList(RandomListNode head)
        {
            RandomListNode copyNode = head, next;

            while (head != null)
            {
                next = head.next;
                var copy = new RandomListNode(head.label);
                head.next = copy;
                copy.next = next;

                head = next;
            }

            //return copyNode;

            var newCopyNode = copyNode;
            while (copyNode != null)
            {
                if (copyNode.random != null)
                    copyNode.next.random = copyNode.random.next;
                copyNode = copyNode.next.next;
            }

            var finalCopyNode = newCopyNode;
            while (newCopyNode != null)
            {
                var nextNode = newCopyNode.next.next;
                newCopyNode.next = nextNode;
                newCopyNode = nextNode;
            }

            return finalCopyNode;
        }
    }
}
