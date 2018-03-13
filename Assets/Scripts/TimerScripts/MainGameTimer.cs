using UnityEngine;
using UnityEngine.UI;

namespace TimerScripts
{
	public class MainGameTimer : Timer
	{
		[SerializeField] private Text timerText;
	
		void Start ()
		{
			timeLeft = 90;
		}

		protected override void TimeIsOver()
		{
			//todo: инициировать конец игры
			this.gameObject.SetActive(false);
			FindObjectOfType<UIController>().EndGameTimer();
		}

		private string timeString;
		protected override void SetTimeValue()
		{
			timeString = ConvertTimeLeftToTimeString();
			timerText.text = timeString;
		}


		private int minutes, seconds;
		private string minutesCountString, secondsCountString; 
		private string ConvertTimeLeftToTimeString()
		{
			minutes = (int)timeLeft / 60;
			seconds = (int) timeLeft % 60;

			minutesCountString = (minutes < 10) ? string.Concat("0", minutes.ToString()) : minutes.ToString();
			secondsCountString = (seconds < 10) ? string.Concat("0", seconds.ToString()) : seconds.ToString();

			return string.Concat(minutesCountString, ":", secondsCountString);
		}
	}
}
