using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTDL_Tuan4
{
    class IntNode
    {
        private int data;
        private IntNode next;
        public int Data
        {
            get { return data; }
            set { data = value; }
        }
        public IntNode Next
        {
            get { return next; }
            set { next = value; }
        }
        public IntNode(int x)
        {
            data = x;
            next = null;
        }
    }

    class MyList
    {
        private IntNode first;
        private IntNode last;
        public IntNode First
        {
            get { return first; }
            set { first = value; }
        }
        public IntNode Last
        {
            get { return last; }
            set { last = value; }
        }
        public MyList()
        {
            first = null;
            last = null;
        }
        public bool IsEmpty()
        {
            return first == null;
        }
        public void AddFirst(IntNode newNode)
        {
            if (IsEmpty())
                first = last = newNode;
            else
            {
                newNode.Next = first;
                first = newNode;
            }
        }
        public void AddLast(IntNode newNode)
        {
            if (IsEmpty())
                first = last = newNode;
            else
            {
                last.Next = newNode;
                last = newNode;
            }
        }
        public void SearchX()
        {
            Console.Write("x = ");
            int x = int.Parse(Console.ReadLine());
            int thutu = 1;
            IntNode p = first;
            while (p != null)
            {
                if (p.Data == x)
                    Console.WriteLine("Vi tri thu " + thutu);
                p = p.Next;
                thutu++;
            }
        }
        public void GetMax()
        {
            int thutu = 1;
            IntNode p = first;
            int max = p.Data;
            while (p != null)
            {
                if (p.Data > max)
                    max = p.Data;
                p = p.Next;
            }
            p = first;
            while (p != null)
            {
                if (p.Data == max)
                    break;
                p = p.Next;
                thutu++;
            }
            Console.WriteLine("max " + max + " o vi tri thu " + thutu);
        }
        public void GetMin()
        {
            int thutu = 1;
            IntNode p = first;
            int min = p.Data;
            while (p != null)
            {
                if (p.Data < min)
                    min = p.Data;
                p = p.Next;
            }
            p = first;
            while (p != null)
            {
                if (p.Data == min)
                    break;
                p = p.Next;
                thutu++;
            }
            Console.WriteLine("min " + min + " o vi tri thu " + thutu);
        }
        public void GetEvenList()
        {
            IntNode p = first;
            MyList evenlist = new MyList();
            MyList oddlist = new MyList();
            while (p != null)
            {
                IntNode newNode = new IntNode(p.Data);

                if (p.Data % 2 == 0)
                    evenlist.AddLast(newNode);
                else
                    oddlist.AddLast(newNode);

                p = p.Next;
            }
            Console.WriteLine("Even list:");
            evenlist.ShowList();
            Console.WriteLine("Odd list:");
            oddlist.ShowList();
        }
        public MyList JoinList(MyList list2)
        {
            MyList list3 = new MyList();

            IntNode p = first;

            while (p != null)
            {
                list3.AddLast(new IntNode(p.Data));
                p = p.Next;
            }

            p = list2.first;

            while (p != null)
            {
                list3.AddLast(new IntNode(p.Data));
                p = p.Next;
            }

            return list3;
        }
        public void Input()
        {
            int x;
            do
            {
                Console.Write("Value (0 to stop): ");
                x = int.Parse(Console.ReadLine());
                if (x == 0)
                    break;
                IntNode newNode = new IntNode(x);
                AddLast(newNode);
            } while (x != 0);
        }
        public void ShowList()
        {
            IntNode p = first;
            while (p != null)
            {
                Console.Write("{0} -> ", p.Data);
                p = p.Next;
            }
            Console.WriteLine("null");
        }
    }


    internal class Program
    {
        static void TestInput()
        {
            MyList list = new MyList();
            list.Input();
            Console.WriteLine("Integer linked list:");
            list.ShowList();
            Console.WriteLine("Even list:");
            list.GetEvenList();
            //list.SearchX();
            //list.GetMax();
            //list.GetMin();

            MyList list2 = new MyList();

            Console.WriteLine("List 2:");
            list2.Input();

            MyList list3 = list.JoinList(list2);

            Console.WriteLine("List 3:");
            list3.ShowList();
        }

        static void Main(string[] args)
        {
            TestInput();
            Console.ReadKey();
        }
    }
}
