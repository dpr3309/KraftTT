using UnityEngine;

public class UIController : MonoBehaviour
{
	[SerializeField] private GameObject gameOverPanel;

	private void Awake()
	{
		gameOverPanel.SetActive(false);
	}

	public void EndGameTimer()
	{
		gameOverPanel.SetActive(true);
	}
}
