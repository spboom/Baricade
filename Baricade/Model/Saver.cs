using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Baricade.Model
{
    public class Saver
    {
        public Saver(Game game, String filename)
        {
            StreamWriter file = new StreamWriter(filename);
            file.WriteLine("<board numberofpawns=\"" + game.Board.NumberOfPawns + "\" height=\"" + game.Board.Height + "\" width=\"" + game.Board.Width + "\">");
            
            for (int i = 0; i < game.Board.Squares.Count; i++)
            {
                Square s = game.Board.Squares[i];
                file.Write("\t<" + s.GetType().Name + " id=\"" + s.Id + "\"");
                if (s.up >= 1)
                {
                    file.Write(" up=\"" + s.up + "\"");
                }
                if (s.left >= 1)
                {
                    file.Write(" left=\"" + s.left + "\"");
                }
                if (s.right >= 1)
                {
                    file.Write(" right=\"" + s.right + "\"");
                }
                if (s.down > 1)
                {
                    file.Write(" down=\"" + s.down + "\"");
                }
                if (s is FinishSquare)
                {
                    file.Write(" x=\"" + s.X + "\" y=\"" + s.Y + "\"");
                }
                file.WriteLine("/>");
            }
           
            for (int i = 0; i < game.Players.Count; i++)
            {
                Player player = game.Players.pop();

                file.WriteLine();
                file.WriteLine("\t<" + player.GetType().Name + " playersquareid=\"" + player.PlayerSquare.Id + "\" color=\"" + player.Color + "\" player=\"" + player.PlayerId + "\" />"); 

                for (int j = 0; j < player.PlayerPawns.Count; j++)
                {
                    Pawn p = player.PlayerPawns[j];

                    if(!(p.Square is PlayerSquare)) {
                        file.WriteLine("\t<" + p.GetType().Name + " playerid=\"" + p.PlayerId + "\" squareid=\"" + p.Square.Id + "\" />"); 
                    }
                }
            }
            for (int i = 0; i < game.Board.Baricades.Count; i++)
            {
                BaricadePiece b = game.Board.Baricades[i];
                if (b.Square == null)
                {
                    file.WriteLine("<" + b.GetType().Name + " playerid=\"" + b.Player.PlayerId + "\"/>");
                }
                else
                {
                    file.WriteLine("<" + b.GetType().Name + " squareid=\"" + b.Square.Id + "\"/>");
                }
            }

            file.WriteLine("</board>");
            file.Close();
        }
    }
}
