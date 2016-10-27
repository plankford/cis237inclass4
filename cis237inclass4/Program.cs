using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    class Program
    {
        static void Main(string[] args)
        {
            IIntegerLinkList myLinkedList = new IntegerLinkList();

            myLinkedList.AddToFront(5);
            myLinkedList.AddToFront(4);
            myLinkedList.AddToFront(3);

            myLinkedList.AddToBack(6);
            myLinkedList.AddToBack(7);
            myLinkedList.AddToBack(8);

            myLinkedList.Display();

            ////This is a generic list
            ////It can hold any type that you declare
            ////This is a built in list to the IDE
            //List<string> foo = new List<string>();

            //*****************************************************************
            //Here is a generic list that will hold strings
            IGenericLinkList<string> myGenericLinkList = new GenericLinkList<string>();

            //Here is a generic linked list that stores any class that implements the IComparable interface
            IGenericLinkList<IComparable> myComparableLinkList = new GenericLinkList<IComparable>();

            //Lets use the string one
            myGenericLinkList.AddToFront("Foo");
            myGenericLinkList.AddToFront("Bar");
            myGenericLinkList.AddToFront("Patrick");
            myGenericLinkList.AddToFront("Lankford");

            myGenericLinkList.AddToBack("Back 3");
            myGenericLinkList.AddToBack("Back 2");
            myGenericLinkList.AddToBack("Back 1");
            myGenericLinkList.AddToBack("Back 0");

            myGenericLinkList.Display();

            string frontGuy = myGenericLinkList.RemoveFromFront();

            Console.WriteLine("This is the string from the front:  " + frontGuy);

        }
    }
}
