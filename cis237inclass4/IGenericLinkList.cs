using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    //This linked list takes in a TYPE that is called T.
    //It is declared in the <> position
    //The name can be anything. We chose T but it
    //can easily be FOO or BAR.
    //You can even do mutiple ones that look like this
    //IGenericLinkList<T1,T2>
    interface IGenericLinkList<T>
    {
        //Since the type we want has come into this interface as a type T
        //we will use T as the type for the data
        //This means that is this linked list is declared with T being
        //a string passed in to T, this list will hold strings. If double is sent in to T
        //it will hold doubles
        void AddToFront(T GenericData);

        void AddToBack(T GenericData);

        T RemoveFromFront();

        T RemoveFromBack();

        void Display();

        bool IsEmpty { get; }

        int Size { get; }
    }
}
