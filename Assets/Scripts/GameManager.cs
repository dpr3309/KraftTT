using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	
	
	void Start () {
		SquareController.ReachedCheckpoint += ReachedCheckpoint;
		
	}

	private void ReachedCheckpoint(int point)
	{
		ScoreManager.Instance.AddPoint(point);
	}

	public void Restart()
	{
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
	}

	public void Exit()
	{
		Application.Quit();
	}
}
