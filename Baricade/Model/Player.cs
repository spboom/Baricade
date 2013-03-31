﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baricade.Model
{
    class Player : XmlData<Player>
    {
        private int playerId;

        public int PlayerId
        {
            get { return playerId; }
            private set { playerId = value; }
        }
        private string color;
        private PlayerSquare playerSquare;
        private List<Pawn> playerPawns;

        public List<Pawn> PlayerPawns
        {
            get { return playerPawns; }
        }
        private BaricadePiece barricade;

        public Player(int player, int pawns, PlayerSquare square)
        {
            this.playerId = player;

            playerPawns = new List<Pawn>();

            for (int i = 0; i < pawns; i++)
            {
                playerPawns.Add(new Pawn(square, this));
            }
        }

        public Player(int player, string color, int pawns, PlayerSquare square)
        {
            this.playerId = player;
            this.color = color;

            playerPawns = new List<Pawn>();

            for (int i = 0; i < pawns; i++)
            {
                addPawn(new Pawn(PlayerSquare, this));
            }
        }

        public string Color
        {
            get { return color; }
            private set { color = value; }
        }

        public PlayerSquare PlayerSquare
        {
            get { return playerSquare; }
            set { playerSquare = value; }
        }

        public BaricadePiece Baricade
        {
            get { return barricade; }
            set { barricade = value; }
        }

        /*
         * Add an new or existing pawn to the player and put it on the playerSquare.
         */
        public void addPawn(Pawn p)
        {
            playerPawns.Add(p);
            p.Square = PlayerSquare;
        }

        /*
         * If a pawn is moved from the playerSquare, then lower the amount.
         */
        public void removePawn()
        {
            playerPawns.RemoveAt(playerPawns.Count);
        }

        public int numberOfPawnsAtStart()
        {
            return playerSquare.Pieces.Count;
        }
    }
}