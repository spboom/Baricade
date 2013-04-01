using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Baricade.Controller;

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
                for(int i=0;i<files.Length;i++)
                {
                    if (files[i].Name == options[i])
                    {
                        controller.loadGame(files[i].FullName);
                        return;
                    }
                }
            }
            for (int i=0;i<files.Length;i++)
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

            }
            Console.WriteLine("no (legit) cheat command given");
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

        }
    }
}
