﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baricade.ViewModel;

namespace Baricade.Model
{
    public class Board : XmlData<Board>
    {
        private int _height;
        private int _width;
        private int _numberOfPawns;
        private ForestSquare _forestSquare;
        private List<BaricadePiece> baricades;
        private List<Square> squares;
        private Square[,] twoDBord;
        private Game game;

        public Game Game
        {
            get { return game; }
            set { game = value; }
        }

        public Square[,] TwoDBord
        {
            get { return twoDBord; }
            private set { twoDBord = value; }
        }
        private VBoard view;

        internal VBoard View
        {
            get { return view; }
            set { view = value; }
        }

        public List<Square> Squares
        {
            get { return squares; }
            set
            {
                squares = value;
                if (value != null)
                {
                    to2D();
                }
            }
        }

        public Square[,] TwoDBoard
        {
            get { return twoDBord; }
            private set { twoDBord = value; }
        }

        private void to2D()
        {
            twoDBord = new Square[Height,Width];

            for (int i = 0; i < squares.Count; i++)
            {
                twoDBord[squares[i].Y, squares[i].X] = squares[i];
            }
        }

        public List<BaricadePiece> Baricades
        {
            get { return baricades; }
            set { baricades = value; }
        }

        public ForestSquare ForestSquare
        {
            get { return _forestSquare; }
            set { _forestSquare = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int NumberOfPawns
        {
            get { return _numberOfPawns; }
            set
            {
                if (value >= 0)
                {
                    _numberOfPawns = value;
                }
                else
                {
                    _numberOfPawns = 4;
                }
            }
        }

        public Board()
        {
            View = new VBoard(this);
            baricades = new List<BaricadePiece>();
            squares = new List<Square>();
        }

        internal bool canMoveTo(Pawn pawn, int x, int y, int moves)
        {
            Square goal = twoDBord[y, x];
            Square[] possibilities = pawn.Square.getNext(pawn.Square, moves, pawn);
            for (int i = 0; i < possibilities.Length; i++)
            {
                if (goal == possibilities[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
