using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
	[SerializeField] private Text scoreLable;

	private void OnEnable()
	{
		scoreLable.text = string.Concat("Score: ", ScoreManager.Instance.CurrentScore.ToString());
	}
}
