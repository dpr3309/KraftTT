using UnityEngine;
using UnityEngine.UI;

namespace TimerScripts
{
	public class ProgressBarTimer : Timer
	{
		[SerializeField] protected Image timeBarImage;
		private int startTimeValue;

		protected virtual void Start ()
		{
			InitTimeLeft();
		}

		private void InitTimeLeft()
		{
			startTimeValue = Random.Range(3, 10);
			timeLeft = startTimeValue;
		}

		protected override void TimeIsOver()
		{
			ResetTimer();
		}

		private void ResetTimer()
		{
			InitTimeLeft();
		}

		protected override void SetTimeValue()
		{
			timeBarImage.fillAmount = timeLeft/startTimeValue;
		}
	}
}
