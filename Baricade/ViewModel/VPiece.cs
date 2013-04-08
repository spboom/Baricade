using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Model;
using System.Windows.Controls;

namespace Baricade.ViewModel
{
    class VPiece
    {
        protected Piece piece;
        protected Image image;

        public VPiece(Piece piece)
        {
            this.piece = piece;
        }

        public Square Square
        {
            get { return Piece.Square; }
            set { Piece.Square = value; }
        }

        public Piece Piece
        {
            get { return piece; }
            protected set { piece = value; }
        }

        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        public virtual string getName()
        {
            return null;
        }

        public virtual char getChar()
        {
            return ' ';
        }
    }
}