using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rockpaperscissor
{
    public class GameController : MonoBehaviour
    {
        private RoundHandler roundHandler;

        void Start()
        {
            roundHandler = new RoundHandler();
        }

        public void PlayerMakesMove(string move)
        {
            IMove playerMove = GetMoveFromString(move);
            IMove aiMove = GetRandomMove();

            roundHandler.SetPlayerMove(playerMove);
            roundHandler.SetAiMove(aiMove);

            Debug.Log(roundHandler.DetermineWinner());
        }

        private IMove GetMoveFromString(string move)
        {
            switch (move.ToLower())
            {
                case "rock":
                    return new Rock();
                case "paper":
                    return new Paper();
                case "scissors":
                    return new Scissors();
                case "lizard":
                    return new Lizard();
                case "spock":
                    return new Spock();
                default:
                    throw new ArgumentException("Invalid move");
            }
        }

        private IMove GetRandomMove()
        {
            System.Random random = new System.Random();
            int move = random.Next(5);

            switch (move)
            {
                case 0:
                    return new Rock();
                case 1:
                    return new Paper();
                case 2:
                    return new Scissors();
                case 3:
                    return new Lizard();
                case 4:
                    return new Spock();
                default:
                    throw new ArgumentException("Invalid move");
            }
        }
    }
}