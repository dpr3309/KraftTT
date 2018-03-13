using UnityEngine;
using UnityEngine.UI;

namespace TimerScripts
{
	[RequireComponent(typeof(Image))]
	public class ProgressBarTimer : Timer
	{
		private Image timeBarImage;
		private int startTimeValue;

		private void Awake()
		{
			timeBarImage = this.GetComponent<Image>();
		}

		void Start ()
		{
			startTimeValue = 10;
			timeLeft = startTimeValue;
		}

		protected override void TimeIsOver()
		{
			//todo: инициировать замену чекпоинта
			
		}

		protected override void SetTimeValue()
		{
			timeBarImage.fillAmount = timeLeft/startTimeValue;
		}
	}
}
