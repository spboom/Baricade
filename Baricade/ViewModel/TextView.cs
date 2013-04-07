using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.ViewModel
{
    class TextView
    {
        // Pieces
        public static char RedPawn = 'R';
        public static char BluePawn = 'B';
        public static char GreenPawn = 'G';
        public static char YellowPawn = 'Y';
        public static char Barricade = '=';

        // Squares
        public static char Square_OpenTag = '(';
        public static char Square_CloseTag = ')';

        public static char PlayerSquare_OpenTag = '<';
        public static char PlayerSquare_CloseTag = '>';

        public static char BarricadeSquare_OpenTag = '+';
        public static char BarricadeSquare_CloseTag = BarricadeSquare_OpenTag;

        public static char BaricadeVillageSquare_OpenTag = ':';
        public static char BaricadeVillageSquare_CloseTag = BaricadeVillageSquare_OpenTag;

        public static char RestSquare_OpenTag = '[';
        public static char RestSquare_CloseTag = ']';

        public static char ForestSquare_OpenTag = '~';
        public static char ForestSquare_CloseTag = ForestSquare_OpenTag;

        public static char FinishSquare_OpenTag = '!';
        public static char FinishSquare_CloseTag = FinishSquare_OpenTag;

        public static char VillageSquare_OpenTag = '{';
        public static char VillageSquare_CloseTag = '}';

        //link
        public static char Connector_OpenTag = ' ';
        public static char Connector_CloseTag = Connector_OpenTag;
    }
}