using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rockpaperscissor
{


    public class GameData 
    {
        public enum MOVE
        {
            ROCK = 1,
            PAPER = 2,
            SCISSORS = 3,
            SPOCK = 4,
            LIZARD = 5
        }

        public class Constants
        {
            public const float SHOW_BLAST_DUR = 2f;
            public const float HIDE_BLAST_DUR = 2f;

            public const float ICON_SHUFFLE_DUR = .1f;
            public const float ROUND_START_DUR = 1f;

        }
    }
}