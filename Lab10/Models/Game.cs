using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab10.Models
{
    public class Game
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public string[] BoxValues { get; set; }

        public string CurrentPlayerName { get; set; }

        public Player CurrentPlayer()
        {
            if (Player1.Name == CurrentPlayerName)
            {
                return Player1;
            }
            else
            {
                return Player2;
            }
        }

        public bool IsGameOver;

        public bool IsATie;

        public Game()
        {
            NewGame();
        }

        public void NewGame()
        {
            Player1 = new Player { Name = "X", Mark = "X" };
            Player2 = new Player { Name = "O", Mark = "O" };

            CurrentPlayerName = Player1.Name;
            BoxValues = new string[9];
            for (int i = 0; i < BoxValues.Length; i++)
            {   
                BoxValues[i] = "";
            }
            IsGameOver = false;
            IsATie = false;
        }

        public void UpdateSquare(int id)
        {
            BoxValues[id] = CurrentPlayer().Mark;
        }

        public void ChangePlayer()
        {//may have to switch the two names below (P 1 and P 2   after the ?)
            if (CurrentPlayerName == Player1.Name)
            {
                CurrentPlayerName = Player2.Name;
            }
            else
            {
                CurrentPlayerName = Player1.Name;
            }
        }

        public void DetermineIfGameIsWon()
        {
            string m = CurrentPlayer().Mark;
            if ((BoxValues[0] == m) && (BoxValues[1] == m) && (BoxValues[2] == m))
            {
                IsGameOver = true;
            }else if ((BoxValues[3] == m) && (BoxValues[4] == m) && (BoxValues[5] == m))
            {
                IsGameOver = true;
            }else if ((BoxValues[6] == m) && (BoxValues[7] == m) && (BoxValues[8] == m))
            {
                IsGameOver = true;
            }else if ((BoxValues[0] == m) && (BoxValues[3] == m) && (BoxValues[6] == m))
            {
                IsGameOver = true;
            }else if ((BoxValues[1] == m) && (BoxValues[4] == m) && (BoxValues[7] == m))
            {
                IsGameOver = true;
            }else if ((BoxValues[3] == m) && (BoxValues[5] == m) && (BoxValues[8] == m))
            {
                IsGameOver = true;
            }else if ((BoxValues[0] == m) && (BoxValues[4] == m) && (BoxValues[8] == m))
            {
                IsGameOver = true;
            }else if ((BoxValues[2] == m) && (BoxValues[4] == m) && (BoxValues[6] == m))
            {
                IsGameOver = true;
            }else if ((BoxValues[0] != "") && (BoxValues[1] != "") && (BoxValues[2] != "") && (BoxValues[3] != "") && (BoxValues[4] != "") && (BoxValues[5] != "") && (BoxValues[6] != "") && (BoxValues[7] != "") && (BoxValues[8] != ""))
            {
                IsGameOver = true;
                IsATie = true;
            }
        }
    }
}
