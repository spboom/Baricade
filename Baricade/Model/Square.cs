﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Baricade.Model
{
    class Square : XmlData<Square>
    {
        private Image image;
        private Piece piece;
        protected bool mayContainBaricade;

        protected Image Image
        {
            get { return image; }
            set { image = value; }
        }

        public Piece Piece
        {
            get { return piece; }
            set { piece = value; }
        }

        public Square()
        {
            mayContainBaricade = true;
        }

    }
}
