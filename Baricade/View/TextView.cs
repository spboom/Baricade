using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Baricade.Controller;
using Baricade.ViewModel;
using Baricade.Model;

namespace Baricade.View
{
    class TextView
    {
        private string commandline;
        private GameController controller;

        public TextView(GameController controller)
        {
            Console.Title = "Welcome to Baricade \ntype \"help\" for help";
            Console.BufferWidth *= 2;
            this.controller = controller;
            show();
            Console.WriteLine("Welcome to Baricade \ntype \"help\" for help");
            while (true)
            {
                if (controller.Game.CurrentPlayer.Human)
                {
                    String line = Console.ReadLine().ToLower();
                    line.Trim();
                    String[] options = line.Split(' ');
                    Console.Clear();
                    commandline = line;
                    show();
                    check(options);
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    AIPlayer();
                }
                }
        }

        private void check(string[] options)
        {
            switch (options[0].ToLower())
            {
                case "help":
                    printHelp();
                    break;
                case "load":
                    load(options);
                    break;
                case "cheat":
                    cheat(options);
                    break;
                case "save":
                    save(options);
                    break;
                case "move":
                    move(options);
                    break;
                case "newgame":
                    NewGame(options);
                    break;
                case "throwdice":
                    controller.Game.throwDice();
                    show();
                    Console.WriteLine("you have thrown "+controller.Game.CurrentDiceRoll);
                    break;
                default:
                    printHelp();
                    break;
            }
        }

        private void NewGame(string[] options)
        {
            DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory + "\\Data\\Level");
            FileInfo[] files = dir.GetFiles();
            if (options.Length > 2)
            {
                int humanPlayers;
                if(int.TryParse(options[2],out humanPlayers))
                {
                    FileInfo file = null;
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (files[i].Name == options[1])
                        {
                            file = files[i];
                            break;
                        }
                    }
                    if (file != null)
                    {
                        Console.Clear();
                        Console.WriteLine(commandline);
                        Console.WriteLine("Creating new Game...");
                        System.Threading.Thread.Sleep(2500);
                        controller.newGame(humanPlayers, file.FullName);
                        show();
                        Console.WriteLine("New Game Started!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Board " + options[1] + " doesn't exist!");
                    }
                }
            }
            Console.WriteLine("newGame bordFileName #ofHumanPlayers");
            Console.WriteLine("  bordFileName:");
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine("    "+files[i]);
            }
            Console.WriteLine("  #ofHumanPlayers:");
            Console.WriteLine("    any number between 0 and 4");


        }

        private void move(string[] options)
        {
            if (controller.Game.CurrentDiceRoll != 0)
            {
                List<String> codes = new List<string>();
                for (int i = 0; i < controller.Game.CurrentPlayer.PlayerPawns.Count; i++)
                {
                    Square square = controller.Game.CurrentPlayer.PlayerPawns[i].Square;

                    Square[] squares = square.getNext(square, controller.Game.CurrentDiceRoll);

                    for (int j = 0; j < squares.Length; j++)
                    {
                        codes.Add("P" + (i + 1) + ":" + (squares[j].X + 1) + ", " + (squares[j].Y + 1));
                    }
                    if (codes.Count == 0)
                    {
                        codes.Add("skip");
                    }
                }

                if (options.Length > 1)
                {
                    if (options[1] == "skip" && codes[0] == "skip")
                    {
                        controller.Game.nextTurn();
                        show();
                        return;
                    }
                    else
                    {
                        char[] splitOn = { ':', ',', ' ' };
                        string[] split = options[1].Split(splitOn);
                        if (split.Length == 3)
                        {
                            if (split[0] == "B")
                            {
                                if (controller.Game.CurrentPlayer.Baricade != null)
                                {
                                    int x, y;
                                    if (int.TryParse(split[1], out x) && int.TryParse(split[2], out y))
                                    {
                                        x--;
                                        y--;
                                        if (x >= 0 && y >= 0 && y <= controller.Game.Board.TwoDBoard.GetUpperBound(0) && x <= controller.Game.Board.TwoDBoard.GetUpperBound(1))
                                        {
                                            if (controller.Game.movePiece(controller.Game.CurrentPlayer.Baricade, controller.Game.Board.TwoDBoard[y, x]))
                                            {
                                                Console.WriteLine("Baricade moved to (" + split[1] + ", " + split[2] + ")");
                                            }
                                            else
                                            {
                                                Console.WriteLine("can't move to (" + split[1] + ", " + split[2] + ")");
                                            }
                                        }
                                    }
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("You dont have a Baricade in your hand.");
                                    return;
                                }
                            }
                            else
                            {
                                int i;
                                string[] init = split[0].Split('p');
                                if (init.Length == 2 && int.TryParse(init[1], out i) && i - 1 < controller.Game.CurrentPlayer.PlayerPawns.Count && i - 1 >= 0)
                                {
                                    i--;
                                    int x, y;
                                    if (int.TryParse(split[1], out x) && int.TryParse(split[2], out y))
                                    {
                                        x--;
                                        y--;
                                        if (x >= 0 && y >= 0 && y <= controller.Game.Board.TwoDBoard.GetUpperBound(0) && x <= controller.Game.Board.TwoDBoard.GetUpperBound(1))
                                        {
                                            if (controller.Game.Board.canMoveTo(controller.Game.CurrentPlayer.PlayerPawns[i], x, y, controller.Game.CurrentDiceRoll))//TODO
                                            {
                                                if (controller.Game.movePiece(controller.Game.CurrentPlayer.PlayerPawns[i], controller.Game.Board.TwoDBoard[y, x]))
                                                {
                                                    if (controller.Game.CurrentPlayer.Baricade == null)
                                                    {
                                                        controller.Game.nextTurn();
                                                    }

                                                    show();
                                                    Console.WriteLine(split[0] + " moved to (" + split[1] + ", " + split[2] + ")");
                                                    
                                                    if (!controller.Game.CurrentPlayer.Human)
                                                    {
                                                        AIPlayer();
                                                    }
                                                    return;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("Move Pawn:");
                Console.WriteLine("P#:X, Y");
                Console.WriteLine("Place Baricade:");
                Console.WriteLine("B:X, Y");
                Console.WriteLine();
                Console.WriteLine("possibilities:");
                for (int i = 0; i < codes.Count; i++)
                {
                    Console.WriteLine(codes[i]);
                }
                return;
            }
            Console.WriteLine("you must throw the dice first!");
        }

        private void AIPlayer()
        {
            while (!controller.Game.CurrentPlayer.Human)
            {
                controller.Game.throwDice();
                show();
                //System.Threading.Thread.Sleep(2500);
                Console.ReadLine();
                controller.Game.CurrentPlayer.bestmove(controller.Game.CurrentDiceRoll);
                controller.Game.nextTurn();
                show();
            }
        }

        private void save(string[] options)//TODO:make
        {
            if (options.Length > 1)
            {
                String name = options[1];
                String[] split = name.Split('.');
                if (split.Length >= 2 && split[split.Length - 1] == "xml")
                {
                    DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory + "\\Data\\Saves");
                    FileInfo[] files = dir.GetFiles();
                    bool exists = false;
                    for (int i = 0; i < files.Length; i++)
                    {
                        if (files[i].Name == name)
                        {
                            exists = true;
                        }
                    }
                    if (exists)
                    {
                        String awnser = null;
                        while (!(awnser == "y" || awnser == "n"))
                        {
                            Console.Clear();
                            show();
                            Console.WriteLine(commandline);
                            Console.WriteLine("File already exists do you want to override it? y/n");
                            awnser = Console.ReadLine();
                            awnser.ToLower();
                        }
                        if (awnser == "n")
                        {
                            Console.WriteLine("Saving canceled");
                            return;
                        }
                    }
                    try
                    {
                        new Saver(controller.Game, Environment.CurrentDirectory + "\\Data\\Saves\\" + name);
                        Console.WriteLine("Saving...");
                        System.Threading.Thread.Sleep(2500);
                        Console.WriteLine("done");
                        return;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("there was an error when saving, try again with an other file name.");
                    }
                }
            }

            Console.WriteLine("give a legit name for the save file");
        }

        private void load(string[] options)
        {
            DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory + "\\Data\\Saves");
            FileInfo[] files = dir.GetFiles();
            if (options.Length > 1)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Name == options[1])
                    {
                        controller.loadGame(files[i].FullName);
                        Console.Clear();
                        Console.WriteLine(commandline);
                        Console.WriteLine("loading...");
                        System.Threading.Thread.Sleep(2500);
                        Console.WriteLine("done");
                        show();
                        return;
                    }
                }
            }
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Extension == ".xml")
                {
                    Console.WriteLine(files[i].Name);
                }
            }
        }

        private void cheat(string[] options)//TODO: improve
        {
            if (options.Length > 1)
            {
                if (options[1] == "currentplayer")
                {
                    if (options.Length > 2)
                    {
                        setCurrentPlayer(options[2]);
                        return;
                    }
                }
                else if (options[1] == "currentdice")
                {
                    if (options.Length > 2)
                    {
                        setCurrentDice(options[2]);
                        Console.Clear();
                        show();
                        Console.WriteLine();
                        Console.WriteLine(commandline);
                        return;
                    }
                }
            }
            Console.WriteLine("cheat:");
            Console.WriteLine("currentplayer #");
            for (int i = 0; i < controller.Game.Players.List.Count; i++)
            {
                Console.WriteLine("\t " + i + ":" + controller.Game.Players.List[i].Color);
            }
            Console.WriteLine("currentdice #");
            Console.WriteLine("number between 1 and 6");
        }

        private void setCurrentDice(string p)
        {
            int i = 0;
            if (int.TryParse(p, out i))
            {
                controller.Game.CurrentDiceRoll = i;
                return;
            }
            Console.WriteLine("Not a number: " + p);
        }

        private void setCurrentPlayer(string p)
        {
            int i = 0;
            if (int.TryParse(p, out i))
            {
                controller.Game.Players.setCurrent(i);
                return;
            }
            Console.WriteLine("Not a number: " + p);
        }

        private void printHelp()
        {
            Console.WriteLine("help:       displays this text, if you type anything that isn't recognized this is also dislpayed");
            Console.WriteLine("            however if you type a command without it's parameters it wil display what options you have with that command");
            Console.WriteLine("load:       prints all the files possible to load when a filename is mentioned after load the specified file is loaded");
            Console.WriteLine("cheat:      print all the possible cheats if you want to use one type the command behind \"cheat\"");
            Console.WriteLine("save:       saves current game with given name don't forget the \".xml\" extension");
            Console.WriteLine("move:       moves the specified pawn or places the baricade in possesion to the given coördinates");
            Console.WriteLine("newGame:    creates a new game with the given board and number of human players");
            Console.WriteLine("throwdice:  does exactly what you would expect, it rolls the dice if you didn't do that already");
        }

        private void show()
        {
            Board bord = controller.Game.Board;
            Square[,] field = bord.TwoDBord;
            String[,] text = new String[field.GetUpperBound(0) * 2 + 1, field.GetUpperBound(1) * 2 + 1];
            for (int y = 0; y <= text.GetUpperBound(0); y++)
            {
                for (int x = 0; x <= text.GetUpperBound(1); x++)
                {
                    text[y, x] = "   ";
                }
            }
            int Yofset = 0;
            int Ymax = text.GetUpperBound(0), Xmax = text.GetUpperBound(1);
            string hor = "---";
            string ver = " | ";
            for (int y = 0; y <= field.GetUpperBound(0); y++)
            {
                int Xofset = 0;
                for (int x = 0; x <= field.GetUpperBound(1); x++)
                {
                    if (field[y, x] != null)
                    {
                        text[y + Yofset, x + Xofset] = field[y, x].View.getText();
                        for (int i = 0; i < field[y, x].links.Length; i++)
                        {
                            bool NotNull = field[y, x].links[i] != null;
                            switch (i)
                            {
                                case 0:
                                    if (NotNull && y + Yofset - 1 >= 0)
                                    {
                                        text[y + Yofset - 1, x + Xofset] = ver;
                                    }
                                    break;
                                case 1:
                                    if (NotNull && x + Xofset + 1 < Xmax)
                                    {
                                        text[y + Yofset, x + Xofset + 1] = hor;
                                    }
                                    break;
                                case 2:
                                    if (NotNull && y + Yofset + 1 < Ymax)
                                    {
                                        text[y + Yofset + 1, x + Xofset] = ver;
                                    }
                                    break;
                                case 3:
                                    if (NotNull && x + Xofset - 1 >= 0)
                                    {
                                        text[y + Yofset, x + Xofset - 1] = hor;
                                    }
                                    break;
                            }
                        }
                    }
                    else
                    {
                        text[y + Yofset, x + Xofset] = "   ";
                    }
                    Xofset++;
                }
                Yofset++;
            }

            //actual printing
            //"\ X:  01    02    03"
            //"Y   __________________"
            //"01 | < >---< >---< >"
            Console.Clear();
            Console.WriteLine("Current turn: " + controller.Game.CurrentPlayer.Color.ToString());
            Console.Write("Dice throw: " + controller.Game.CurrentDiceRoll);
            if (controller.Game.CurrentDiceRoll == 0)
            {
                Console.Write(" use the commando throwdice to start your turn");
            }
            Console.WriteLine();
            if (controller.Game.CurrentPlayer.Baricade != null)
            {
                Console.WriteLine("There is a Baricade in possesion. you must place it to end your turn");
            }
            Console.Write("\\ X:");
            String underLine = "   ";
            for (int i = 0; i <= text.GetUpperBound(1)/2; i++)
            {
                string s = "";
                if (i + 1 < 10)
                {
                    s = " ";
                }
                s += (i + 1).ToString();
                Console.Write("  " + s + "  ");
                underLine += "______";
            }
            Console.WriteLine();
            Console.WriteLine("Y" + underLine);
            for (int y = 0; y <= text.GetUpperBound(0); y++)
            {
                if (y % 2 == 0)
                {
                    if (((y/2) + 1) < 10)
                    {
                        Console.Write(" " + ((y/2)+1));
                    }
                    else
                    {
                        Console.Write((y/2)+1);
                    }
                }
                else
                {
                    Console.Write("  ");
                }
                Console.Write(" | ");
                for (int x = 0; x <= text.GetUpperBound(1); x++)
                {
                    Console.Write(text[y, x]);
                }
                Console.WriteLine(" |");
            }
            Console.WriteLine(" " + underLine);
            Console.WriteLine();
            if (commandline == "")
            {
                commandline = "<empty>";
            }
            Console.WriteLine("Command: " + commandline);
            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
