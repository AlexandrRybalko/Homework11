using System.Collections;
using System.Collections.Generic;

namespace Homework11
{
    public class MyListEnumerator<T> : IEnumerator<T>
    {
        private MyList<T> _myList;
        private int position;

        public MyListEnumerator(MyList<T> myList)
        {
            _myList = myList;
            position = -1;
        }

        public object Current => _myList[position].Value;

        T IEnumerator<T>.Current => _myList[position].Value;

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public bool MoveNext()
        {
            if (position < _myList.Count() - 1)
            {
                position++;

                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
