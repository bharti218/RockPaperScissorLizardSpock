using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rockpaperscissor
{
    public class Paper : IMove
    {
        public bool Kills(IMove otherMove)
        {
            return otherMove is Rock || otherMove is Spock;
        }

        public string GetMoveName()
        {
            return "Paper";
        }


    }
}