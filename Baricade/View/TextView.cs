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
                String line = Console.ReadLine().ToLower();
                line.Trim();
                String[] options = line.Split(' ');
                Console.Clear();
                show();
                Console.WriteLine();
                if (line == "")
                {
                    line = "<empty>";
                }
                commandline = "Command: " + line;
                Console.WriteLine(commandline);
                Console.WriteLine();
                Console.WriteLine();
                check(options);
                Console.WriteLine();
                Console.WriteLine();
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
                default:
                    printHelp();
                    break;
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

        private void cheat(string[] options)//TODO: Make
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
            Console.WriteLine("help:    displays this text");
            Console.WriteLine("load:    prints all the files possible to load when a filename is mentioned after load the specified file is loaded");
            Console.WriteLine("cheat:   print all the possible cheats if you want to use one type the command behind \"cheat\"");
            Console.WriteLine("save:    saves current game with given name don't forget the \".xml\" extension");
            Console.WriteLine("move:    ");
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
                            string line = "   ";
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
            Console.WriteLine("Current turn: " + controller.Game.CurrentPlayer.Color.ToString());
            Console.WriteLine("Dice throw: " + controller.Game.CurrentDiceRoll);
            Console.Write("\\ X:");
            String underLine = "   ";
            for (int i = 0; i <= text.GetUpperBound(1)/2; i++)
            {
                string s = "";
                if (i + 1 < 10)
                {
                    s = "0";
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
                        Console.Write("0" + ((y/2)+1));
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
                Console.WriteLine("|");
            }
            Console.WriteLine(" " + underLine);
        }
    }
}
