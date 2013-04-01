using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Baricade.Model
{
    class Saver
    {
        public Saver(Game game, String name)
        {
            StreamWriter file = new StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory + "Data/Saves/" + name + ".xml");
            file.WriteLine("<board numberofpawns=\""+game.Board.NumberOfPawns+"\">");
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
                file.WriteLine(" />");
            }
            for (int i = 0; i < game.Players.Count; i++)
            {
                Player player = game.Players.next();
                file.WriteLine("\t<" + player.GetType().Name + " playersquareid=\"" + player.PlayerSquare.Id + "\" color=\"" + player.Color + "\" player=\"" + player.PlayerId + "\" />");
                for (int j = 0; j < player.PlayerPawns.Count; j++)
                {
                    Pawn p = player.PlayerPawns[j];
                    file.WriteLine("\t\t<" + p.GetType().Name + " playerid=\"" + p.PlayerId + "\" square=\"" + p.Square.Id + "\" />");
                }
            }
            file.WriteLine("</board>");
            file.Close();
        }
    }
}
