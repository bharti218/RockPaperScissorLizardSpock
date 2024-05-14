using System;
using System.Collections;
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
        [SerializeField] float reward;
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
            AudioController.Instance.PlayUISound();
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
                hudController.SetComputerScore(reward);
                hudController.ShowGameOverPanel();
                yield return new WaitForSeconds(GameData.Constants.RESULT_PANEL_SHOW_DUR);
                ShowMainMenu();
            }
            else
            {
                if (string.Compare(result, "player") == 0)
                {
                    hudController.SetPlayerScore(reward);
                    hudController.ShowYouWinPanel();
                    yield return new WaitForSeconds(GameData.Constants.RESULT_PANEL_SHOW_DUR);
                }
                StartRound();
            }
            hudController.HideResultPanels();
            Debug.Log(roundHandler.DetermineWinner());
        }

        internal void OnTimeUp()
        {
            hudController.ShowGameOverPanel();
            Invoke(nameof(ShowMainMenu), GameData.Constants.RESULT_PANEL_SHOW_DUR);
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
            AudioController.Instance.PlayClickSound(); 
            hudController.HideResultPanels();
            mainMenu.SetActive(false);
            StartRound();
        }

        private void ShowMainMenu()
        {
            playerMoveDisplay.shuffling = false;
            computerMoveDisplay.shuffling = false;
            mainMenu.SetActive(true);
        }

        private void StartRound()
        {
            hudController.SetButtonInteraction(true);
            hudController.ResetBtnScale();
            playerMoveDisplay.ShuffleIcons();
            computerMoveDisplay.ShuffleIcons();
            timer.StartTimer(maxTime);
        }

        
    }
}