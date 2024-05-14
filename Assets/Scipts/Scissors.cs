using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rockpaperscissor
{

    public class Scissors : IMove
    {
        public bool Kills(IMove otherMove)
        {
            return otherMove is Paper || otherMove is Lizard;
        }

        public GameData.MOVE GetMoveName()
        {
            return GameData.MOVE.SCISSORS;
        }
    }
}