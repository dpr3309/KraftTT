namespace TimerScripts
{
	public class CheckPointTimer : ProgressBarTimer
	{
		private CheckPoint checkPoint;

		protected override void Start()
		{
			base.Start();
			checkPoint = this.GetComponent<CheckPoint>();
		}

		protected override void TimeIsOver()
		{
			checkPoint.ChangeColor();
			base.TimeIsOver();
		}
	}
}