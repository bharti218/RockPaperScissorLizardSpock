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
                return "Player wins! " + playerMove.GetMoveName() + " defeats " + aiMove.GetMoveName();
            }
            else if (aiMove.Kills(playerMove))
            {
                return "AI wins! " + aiMove.GetMoveName() + " defeats " + playerMove.GetMoveName();
            }
            else
            {
                return "It's a tie!";
            }
        }
    }
}