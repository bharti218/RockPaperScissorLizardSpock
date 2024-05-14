using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rockpaperscissor
{

    public class Spock : IMove
    {
        public bool Kills(IMove otherMove)
        {
            return otherMove is Rock || otherMove is Scissors;
        }

        public string GetMoveName()
        {
            return "Spock";
        }
    }
}
