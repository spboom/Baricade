using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class Circuit<T>
    {
        public int Count { get { return list.Count; } }
        private List<T> list;
        private int pointer;

        private int Pointer
        {
            get { return pointer; }
            set
            {
                if (value > pointer)
                {
                    if (value > list.Count-1)
                    {
                        pointer = 0;
                    }
                }
                else if (value < pointer)
                {
                    if (value < 0)
                    {
                        pointer = list.Count - 1;
                    }
                }
                else if (value == pointer)
                {

                }
            }
        }
        public Circuit()
        {
            list = new List<T>();
        }

        public T peek()
        {
            return list[pointer];
        }

        public T Pop()
        {
            return list[Pointer++];
        }
        
        public T previous()
        {
            return list[--Pointer];
        }

        public T next()
        {
            return list[++Pointer];
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
    }
}
