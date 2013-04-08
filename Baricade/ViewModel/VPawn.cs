using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.Model;
namespace Baricade.ViewModel
{
    class VPawn : VPiece
    {
        public VPawn(Pawn pawn) : base(pawn) {}

        public override string getName()
        {
            string name;

            switch (Piece.Player.Color)
            {
                case PlayerColor.Red:
                    name = "redPawn";
                    break;
                case PlayerColor.Blue:
                    name = "bluePawn";
                    break;
                case PlayerColor.Green:
                    name = "greenPawn";
                    break;
                case PlayerColor.Yellow:
                    name = "yellowPawn";
                    break;
                default:
                    name = "?";
                    break;
            }

            return name;
        }

        public override char getChar()
        {
            char character;

            switch(Piece.Player.Color)
            {
                case PlayerColor.Red:
                    character = TextView.RedPawn;
                    break;
                case PlayerColor.Blue:
                    character = TextView.BluePawn;
                    break;
                case PlayerColor.Green:
                    character = TextView.GreenPawn;
                    break;
                case PlayerColor.Yellow:
                    character = TextView.YellowPawn;
                    break;
                default:
                    character = '?';
                    break;
            }

            return character;
        }
    }
}