using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    class IntegerLinkList : IIntegerLinkList
    {
        //Make a class inside this class
        //This is an inner class. It will serve as our Node class for the linked list
        //Because it is an inner class, it can't be used outside this class, which is
        //ok since we dont need it anywhere but in here.
        protected class Node
        {
            //Node has 2 properties. Data, to store the data
            //and Next to point to the next Node in the list
            public int Data { get; set; }
            public Node Next { get; set; }
        }

        //Head and Tail to point to the beginning and end of the linked list nodes
        protected Node _head;
        protected Node _tail;
        protected int _size;    //Does this really need an explanation?

        //Check to see if the head is null. If the head pointer is null, ther is nothing in
        //the list
        public bool IsEmpty
        {
            get
            {
                return _head == null;
            }
        }

        //Get the size by returning the backing fields value
        public int Size
        {
            get
            {
                return _size;
            }
        }

        public void AddToFront(int IntegerData)
        {
            //Make a new pointer named oldNode that points to the same place as the
            //head variable points to.
            Node oldHead = _head;

            //Create a new Node and store that in the head variable
            _head = new Node();

            //Set the data on the new node
            _head.Data = IntegerData;

            //Set the next property on the oldHead
            _head.Next = oldHead;

            //Increase the size
            _size++;

            //If the size is equal the one, which means, old node only
            //the head and the tail are the same, so lets set them that way
            if(_size == 1)
            {
                _tail = _head;
            }
        }

        public void AddToBack(int IntegerData)
        {
            //Create a new node that points to the same location as the tail
            Node oldTail = _tail;

            //Create a new node and put it in the tail variable
            _tail = new Node();

            //Set the data
            _tail.Data = IntegerData;

            //Set the Next to null since this is the last Node
            _tail.Next = null;

            //We can check to see if the list is empty. Empty is the head pointing to null
            //Since on and initial add, adding is done to the tail,
            //head is still null. We want head and tail
            //to point to the same first node
            //Therefore if the list is empty , just add to the head equal to the tail
            if(IsEmpty)
            {
                _head = _tail;
            }
            /*
             * Otherwise, this is not an initial add. It is with an established list
             * so we just need to set the oldTails next pointer to the new tail we created
             * */
            else
            {
                oldTail.Next = _tail;
            }
            //Dont forget to increase the size of the linked list
            _size++;          
        }

        public int RemoveFromFront()
        {
            if (IsEmpty)
            {
                throw new Exception("List is Empty");
            }

            //Get out the data that needs to be returned
            int returnData = _head.Data;

            /*
             * Move the head to the next node in the list
             * luckiy head knows where the next node is byt its Next property
             * */
            _head = _head.Next;

            //*****Now that there are now variables that point to where the old head is
            //the garbage collector can come clean up that node for us

            //Decrement the size
            _size--;

            /*
             * Check to see if we just removed the last node in the list
             * if so, we want to set the tail to null as well
             * */
            if (IsEmpty)
            {
                _tail = null;
            }

            return returnData;
        }

        //This one takes more work than the other 3
        //Keep this in mind for the assignment
        public int RemoveFromBack()
        {
            if (IsEmpty)
            {
                throw new Exception("The list is empty");
            }

            //Get the data from the tail node. This is what we will return
            int returnData = _tail.Data;

            //If we are in the situation where ther ie only one node left, and
            //that is the one I want to remove, I need to set both head and tail
            //to null. That way there is no reference to the last node and the garbage
            //collector can come pick it up
            if (_head == _tail)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                //Create a current node and start it at the head. Just like in the
                //display method. This way we can walk the list
                Node current = _head;

                //While current's next property is not equal to the tail
                //Which means we are not at the node that is right before the tail
                while (current.Next != _tail)
                {
                    current = current.Next;
                }

                //When we get there we will set the tail to the current node we are
                //at
                _tail = current;

                //Set the next property of the current to null so the last node that
                //was removed has no reference pointing to it.
                current.Next = null;
            }

            //return he return data
            return returnData;
        }

        public void Display()
        {
            if (IsEmpty)
            {
                Console.WriteLine("The list is empty");
            }
            else
            {
                Console.WriteLine("This list is:");

                //Define a node that starts pointing at the same place as head
                Node current = _head;

                /*
                 * While the current pointer is not null.
                 * being null would suggest that it is now pointing to a location
                 * that is past the end of the list, (Or the end of the list)
                 * */
                while (current != null)
                {
                    //Write out the data
                    Console.Write(current.Data + ", ");
                    /*
                     * Move the current pointer to the next Node in the list
                     * we can accomplish this by taking th epointer that is in
                     * the current nodes next property, and assigning it to the
                     * current variable
                     * */
                    current = current.Next;
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        } 
        
        //Constructor
        public IntegerLinkList()
        {
            _head = null;
            _tail = null;
            _size = 0;
        }       
    }
}
