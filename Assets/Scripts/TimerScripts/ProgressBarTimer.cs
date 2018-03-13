using UnityEngine;
using UnityEngine.UI;

namespace TimerScripts
{
	public class ProgressBarTimer : Timer
	{
		[SerializeField] private Image timeBarImage;
		private int startTimeValue;


		void Start ()
		{
			startTimeValue = Random.Range(3, 10);
			timeLeft = startTimeValue;
		}

		protected override void TimeIsOver()
		{
			//todo: инициировать цвета замену чекпоинта
			this.GetComponent<CheckPoint>().ChangeColor();
			ResetTimer();

		}

		private void ResetTimer()
		{
			timeLeft = startTimeValue;
		}

		protected override void SetTimeValue()
		{
			timeBarImage.fillAmount = timeLeft/startTimeValue;
		}
	}
}
