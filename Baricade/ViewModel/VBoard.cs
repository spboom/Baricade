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

        public VBoard(Board board)
        {
            this.board = board;
        }

        public Image[,] getImageBoard()//TODO
        {
            return null;
        }

        public String[,] getStrignBoard()//TODO
        {
            return null;
        }
    }
    
}
