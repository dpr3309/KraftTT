using UnityEngine;

namespace TimerScripts
{
	public abstract class Timer : MonoBehaviour
	{
		protected float timeLeft;
	
		void Update ()
		{
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0)
			{
				TimeIsOver();
				return;
			}
			SetTimeValue();
		}

		protected abstract void TimeIsOver();

		protected abstract void SetTimeValue();
	}
}
