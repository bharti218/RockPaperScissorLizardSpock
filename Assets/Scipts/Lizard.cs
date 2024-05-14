using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace rockpaperscissor
{


    public class Lizard : IMove
    {
        public bool Kills(IMove otherMove)
        {
            return otherMove is Paper || otherMove is Spock;
        }

        public GameData.MOVE GetMoveName()
        {
            return GameData.MOVE.LIZARD;
        }
    }
}