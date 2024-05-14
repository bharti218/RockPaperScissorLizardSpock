using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

namespace rockpaperscissor
{
    public class HudController : MonoBehaviour
    {
        [SerializeField] List<Button> moveBtns;
        [SerializeField] GameObject blackFade;
        [SerializeField] GameObject youWin;
        [SerializeField] GameObject gameOver;
        [SerializeField] TextMeshProUGUI computerScore;
        [SerializeField] TextMeshProUGUI playerScore;
        [SerializeField] TextMeshProUGUI highScore;
        private float computerScr;
        private float playerScr;
        private float highScr;

        private void Start()
        {
            if (PlayerPrefs.HasKey(GameData.Constants.HIGH_SCORE))
            {
                highScr = PlayerPrefs.GetFloat(GameData.Constants.HIGH_SCORE);
                highScore.text = GameData.Constants.HIGH_SCORE_HEADING + highScr.ToString();
            }
        }

        public void SetButtonInteraction(bool isBtnActive)
        {
            for (int i = 0; i < moveBtns.Count; i++)
            {
                moveBtns[i].interactable = isBtnActive;
            }
        }

        public void HoverEffect(int id)
        {
            for (int i = 0; i < moveBtns.Count; i++)
            {
                moveBtns[i].gameObject.transform.localScale = Vector3.one;
            }

            moveBtns[id].gameObject.transform.DOScale(1.2f, .3f);
        }

        public void ShowGameOverPanel()
        {
            youWin.SetActive(false);
            blackFade.SetActive(true);
            gameOver.SetActive(true);
        }

        public void ShowYouWinPanel()
        {
            gameOver.SetActive(false);
            blackFade.SetActive(true);
            youWin.SetActive(true);
        }

        public void HideResultPanels()
        {
            youWin.SetActive(false);
            blackFade.SetActive(false);
            gameOver.SetActive(false);
        }


        public void SetPlayerScore(float reward)
        {
            playerScr += reward;
            playerScore.text = GameData.Constants.PLAYER_SCORE_HEADING +  playerScr.ToString();
            SetHighScore();
        }

        public void SetComputerScore(float reward)
        {
            computerScr += reward;
            computerScore.text = GameData.Constants.COMPUTER_SCORE_HEADING + computerScr.ToString();
            SetHighScore();
        }

        private void SetHighScore()
        {
            if (playerScr > computerScr)
                highScr = playerScr;
            else
                highScr = computerScr;
            highScore.text = GameData.Constants.HIGH_SCORE_HEADING + highScr.ToString();
            PlayerPrefs.SetFloat(GameData.Constants.HIGH_SCORE, highScr);
        }
    }
}