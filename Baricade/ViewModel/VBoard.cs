using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Model;
using System.Windows.Controls;

namespace Baricade.ViewModel
{
    class VBoard
    {
        private Board board;
        private String style;

        public VBoard(Board board)
        {
            this.board = board;
        }

        public Board Board
        {
            get { return board; }
            private set { board = value; }
        }

        public String Style
        {
            get { return style; }
            set { style = value; }
        }
    }
}