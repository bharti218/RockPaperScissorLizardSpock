using System.Text;
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
        float timeRemaining;
        bool runTimer;
        StringBuilder sb;

        public void StartTimer(float timerValue)
        {
            runTimer = true;
            timerText.text = "";
            timeRemaining = Mathf.CeilToInt(timerValue);

            sb = new StringBuilder();

            if (timerBar != null)
            {
                timerBar.maxValue = timerValue;
                timerBar.value = timerBar.maxValue;
            }

            timerText.text = sb.Insert(0, (int)timeRemaining).ToString();
        }

        public void StopTimer()
        {
            runTimer = false;
        }

        // Timer update
        private void Update()
        {
            if (timeRemaining > 0 && runTimer)
            {
                timerText.text = sb.Replace(timerText.text, ((int)timeRemaining).ToString()).ToString();
                timeRemaining -= Time.deltaTime;
                timerBar.value = timeRemaining;
            }
            if (timeRemaining <= 1 && runTimer)
            {
                gameController.OnTimeUp();
            }


        }
    }
}