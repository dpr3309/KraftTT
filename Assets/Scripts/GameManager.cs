using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static UnityAction InitGameTimer = delegate {  };
	public static UnityAction InitCheckPoints = delegate {  };
	public static UnityAction InitSquares = delegate {  };
	
	void Start () {
		SquareController.ReachedCheckpoint += ReachedCheckpoint;

		Startup();
	}

	private void Startup()
	{
		DataManager.Instance.LoadData();

		InitGameTimer();
		InitCheckPoints();
		InitSquares();
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

	private void OnDestroy()
	{
		InitGameTimer = delegate {  };
		InitCheckPoints = delegate {  };
		InitSquares = delegate {  };
	}
}
