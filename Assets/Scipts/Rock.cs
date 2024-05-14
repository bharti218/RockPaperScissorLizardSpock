using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rockpaperscissor
{
    public class Rock : IMove
    {
        public bool Kills(IMove otherMove)
        {
            return otherMove is Scissors || otherMove is Lizard;

        }

        public string GetMoveName()
        {
            return "Rock";
        }
    }
}