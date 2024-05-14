using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace rockpaperscissor
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] Button playBtn;
        [SerializeField] GameObject mainMenu;

        [SerializeField] MoveDisplay playerMoveDisplay;
        [SerializeField] MoveDisplay computerMoveDisplay;
        [SerializeField] HudController hudController;
        [SerializeField] Timer timer;
        [SerializeField] float maxTime;
        private RoundHandler roundHandler;



        void Start()
        {
            ShowMainMenu();
            roundHandler = new RoundHandler();
            playBtn.onClick.AddListener(ShowGamePlay);
        }

        public void PlayerMakesMove(int move)
        {
            StartCoroutine(PlayeMoveHandler(move));
        }


        IEnumerator PlayeMoveHandler(int move)
        {
            hudController.SetButtonInteraction(false);
            timer.StopTimer();
            IMove playerMove = GetMoveFromString((GameData.MOVE)move);
            IMove aiMove = GetRandomMove();

            playerMoveDisplay.StopShuffling((GameData.MOVE)move);
            computerMoveDisplay.StopShuffling(aiMove.GetMoveName());

            roundHandler.SetPlayerMove(playerMove);
            roundHandler.SetAiMove(aiMove);

            string result = roundHandler.DetermineWinner();

            yield return new WaitForSeconds(GameData.Constants.SHOW_BLAST_DUR);

            if (string.Compare(result, "player") == 0)
                computerMoveDisplay.ShowBlastEffect();
            else if (string.Compare(result, "computer") == 0)
                playerMoveDisplay.ShowBlastEffect();
            yield return new WaitForSeconds(GameData.Constants.ROUND_START_DUR);

            if (string.Compare(result, "computer") == 0)
            {
                ShowMainMenu();
            }
            else
            {
                StartRound();
            }

            Debug.Log(roundHandler.DetermineWinner());
        }

        internal void OnTimeUp()
        {
            
        }

        private IMove GetMoveFromString(GameData.MOVE move)
        {
            switch (move.ToString().ToLower())
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

        private void ShowGamePlay()
        {
            mainMenu.SetActive(false);
            StartRound();
        }

        private void ShowMainMenu()
        {
            mainMenu.SetActive(true);
        }

        private void StartRound()
        {
            hudController.SetButtonInteraction(true);
            playerMoveDisplay.ShuffleIcons();
            computerMoveDisplay.ShuffleIcons();
            timer.StartTimer(maxTime);
        }
    }
}