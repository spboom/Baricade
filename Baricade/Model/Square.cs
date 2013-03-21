using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Baricade.Model
{
    abstract class Square : XmlData<Square>
    {
        private Piece _piece;
        private int id;
        public int up, left, right, down;
        protected bool mayContainBaricade;

        public Piece Piece
        {
            get { return _piece; }
            
            set 
            {
                _piece = value; 
            }
        }

        public abstract string Name { get; }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Up
        {
            get { return up; }
            set { up = value; }
        }

        public int Left
        {
            get { return left; }
            set { left = value; }
        }

        public int Right
        {
            get { return right; }
            set { right = value; }
        }

        public int Down
        {
            get { return down; }
            set { down = value; }
        }
        
        public Square()
        {
            mayContainBaricade = true;
        }

        //public abstract bool isAvailable();
    }
}