using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    public class Circuit<T>
    {
        public int Count { get { return list.Count; } }
        private List<T> list;

        public List<T> List
        {
            get { return list; }
           private set { list = value; }
        }
        private int pointer;

        private int Pointer
        {
            get { return pointer; }
            set
            {
                if (value >= list.Count)
                {
                    pointer = 0;
                }

                else if (value < 0)
                {
                    pointer = list.Count - 1;
                }

                else
                {
                    pointer = value;
                }
            }
        }
       
        public Circuit()
        {
            list = new List<T>();
            Pointer = 0;
        }

        public T peek()
        {
            return list[pointer];
        }

        public T pop()
        {
            return list[Pointer++];
        }
        
        public T previous()
        {
            return list[--Pointer];
        }

        public T next()
        {
            Pointer++;
            return list[Pointer];
        }

        public void Add(T t)
        {
            list.Add(t);
        }


        internal void setCurrent(int position)
        {
            if (position < 0)
            {
                position = 0;
            }
            else if (position >= Count)
            {
                position = Count - 1;
            }
            pointer = position;
        }

        public T getAt(int position)
        {
            return list[position];
        }
    }
}
