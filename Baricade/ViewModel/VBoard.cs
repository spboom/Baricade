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

        public Image[,] getImageBoard() // TODO: Use the method getName() for the filename.
        {
            return null;
        }

        public String[,] getStringBoard() // TODO: Use the method getText() for the text.
        {
            return null;
        }
    }
    
}
