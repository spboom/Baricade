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
        private GameController controller;

        public TextView(GameController controller)
        {
            this.controller = controller;
            Console.WriteLine("Welcome to Baricade \n type \"help\" for help");
            while (true)
            {
                show();
                String line = Console.ReadLine().ToLower();
                String[] options = line.Split(' ');
                check(options);
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
                    save();
                    break;
            }
        }

        private void save()//TODO:make
        {

        }

        private void load(string[] options)//TODO:check
        {
            DirectoryInfo dir = new DirectoryInfo(Environment.CurrentDirectory + "\\Data\\Saves");
            FileInfo[] files = dir.GetFiles();
            if (options.Length > 1)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Name == options[i])
                    {
                        controller.loadGame(files[i].FullName);
                        return;
                    }
                }
            }
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Extension == "xml")
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
                    }
                }
            }
            Console.WriteLine("cheat:\n currentplayer #");
            for (int i = 0; i < controller.Game.Players.List.Count; i++)
            {
                Console.WriteLine("\t " + i + ":" + controller.Game.Players.List[i].Color);
            }
        }

        private void setCurrentPlayer(string p)
        {
            int i = 0;
            if (int.TryParse(p, out i))
            {
                controller.Game.Players.setCurrent(i);
            }
            Console.WriteLine("Not a number: " + p);
        }

        private void printHelp()
        {
            Console.WriteLine("help: displays this text");
            Console.WriteLine("load: prints all the files possible to load when a filename is mentioned after load the specified file is loaded");
            Console.WriteLine("cheat: print all the possible cheats if you want to use one type the command behind \"cheat\"");
            Console.WriteLine("save: saves current game with given name");
        }

        private void show()
        {
            Board bord = controller.Game.Board;
            Square[,] field = bord.TwoDBord;
            String[,] text = new String[field.GetUpperBound(0) * 2 - 1, field.GetUpperBound(1) * 2 - 1];
            int Yofset = 0;
            string hor = "---";
            string ver = " | ";
            for (int y = 0; y < field.GetUpperBound(0); y++)
            {
                int Xofset = 0;
                for (int x = 0; x < field.GetUpperBound(1); x++)
                {
                    if (field[y, x] != null)
                    {
                        text[y + Yofset, x + Xofset] = field[y, x].View.getText();//TODO empty string->"   "!!
                        for (int i = 0; i < field[y, x].links.Length; i++)
                        {
                            bool NotNull = field[y, x].links[i] != null;
                            string line = "   ";
                            switch (i)
                            {
                                case 0:
                                    if (NotNull)
                                    {
                                        line = ver;
                                    }
                                    text[y + Yofset - 1, x + Xofset] = line;

                                    break;
                                case 1: if (NotNull)
                                    {
                                        line = hor;
                                    }
                                    text[y + Yofset, x + Xofset + 1] = line;
                                    break;
                                case 2:
                                    if (NotNull)
                                    {
                                        line = ver;
                                    }
                                    text[y + Yofset + 1, x + Xofset] = line;
                                    break;
                                case 3:
                                    if (NotNull)
                                    {
                                        line = hor;
                                    }
                                    text[y + Yofset, x + Xofset - 1] = hor;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        text[y + Yofset, x + Xofset] = "   ";
                    }
                }
            }
        }
    }
}
