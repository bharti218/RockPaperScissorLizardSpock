using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace rockpaperscissor
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI timerText;
        [SerializeField] GameController gameController;
        [SerializeField] Slider timerBar;
        [SerializeField] Image timerBarImg;
        float timeRemaining;
        bool runTimer;

        public void StartTimer(float timerValue)
        {
            runTimer = true;
            timerText.text = "";
            timeRemaining = Mathf.CeilToInt(timerValue);
            timerBarImg.color = Color.green;

            if (timerBar != null)
            {
                timerBar.maxValue = timerValue;
                timerBar.value = timerBar.maxValue;
            }

            timerText.text =  ((int)timeRemaining).ToString();
        }

        public void StopTimer()
        {
            runTimer = false;
        }

        private void Update()
        {
            if (timeRemaining > 0 && runTimer)
            {
                timerText.text = ((int)timeRemaining).ToString() + "s";
                timeRemaining -= Time.deltaTime;
                timerBar.value = timeRemaining;
            }

            if (timeRemaining <= 3)
                timerBarImg.color = Color.red;

            if (timeRemaining <= 1 && runTimer)
                gameController.OnTimeUp();
            

        }

     
    }
}