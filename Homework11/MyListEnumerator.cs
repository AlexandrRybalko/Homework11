using System.Collections;

namespace Homework11
{
    public class MyListEnumerator<T> : IEnumerator
    {
        private MyList<T> _myList;
        private int position;

        public MyListEnumerator(MyList<T> myList)
        {
            _myList = myList;
            position = -1;
        }

        public object Current => _myList[position].Value;

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
