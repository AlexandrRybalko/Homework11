using System;

namespace Homework11
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> myList1 = new MyList<int>();
            myList1.Add(8);
            myList1.Add(2);
            MyList<int> myList2 = new MyList<int>();
            myList2.Add(1);
            myList2.Add(2);
            myList2.Add(3);
            myList2.Add(4);
            myList2.Add(5);
            myList2.Add(6);
            myList2.Add(7);
            myList2.Add(8);
            myList2.Add(9);

            myList2.Notify += myList1.Add;

            myList2.Remove(1);
            myList2.Remove(7);
            myList2.Remove(5);

            foreach (var a in myList1)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("============================");
            foreach (var a in myList2)
            {
                Console.WriteLine(a);
            }

            Console.ReadKey();
        }
    }
}
