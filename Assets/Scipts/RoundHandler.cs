using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rockpaperscissor
{


    public class RoundHandler
    {
        private IMove playerMove;
        private IMove aiMove;

        public void SetPlayerMove(IMove move)
        {
            playerMove = move;
        }

        public void SetAiMove(IMove move)
        {
            aiMove = move;
        }

        public string DetermineWinner()
        {
            if (playerMove.Kills(aiMove))
            {
                Debug.Log("Player wins! " + playerMove.GetMoveName().ToString() + " defeats " + aiMove.GetMoveName().ToString());
                return "player";
            }
            else if (aiMove.Kills(playerMove))
            {
                Debug.Log("AI wins! " + aiMove.GetMoveName().ToString() + " defeats " + playerMove.GetMoveName().ToString());
                return "computer";
            }
            else
            {
                return "It's a tie!";
            }
        }
    }
}