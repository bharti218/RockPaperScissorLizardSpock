using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

            if (timeRemaining >= 2.99f && timeRemaining <=3f && runTimer)
            {
                timerBarImg.color = Color.red;
                AudioController.Instance.PlayWarningSound();
            }

            if (timeRemaining >= .99f && timeRemaining <= 1f && runTimer)
                gameController.OnTimeUp();

        }


     
    }
}