using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static UnityAction InitGameTimer = delegate {  };
	public static UnityAction InitCheckPoints = delegate {  };

	[SerializeField] private Vector3[] startPositions;
	
	void Start () {

		Startup();
	}

	private void Startup()
	{
		DataManager.Instance.LoadData();

		InitGameTimer();
		InitCheckPoints();

		foreach (var startPosition in startPositions)
		{
			SquareFactory.Instance.CreateSquare(startPosition);
		}

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

	}
}
