using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{

	public static UnityAction InitGameTimer = delegate {  };
	public static UnityAction InitCheckPoints = delegate {  };

	private static GameManager instance;

	public static GameManager Instance
	{
		get { return instance; }
	}
	
	
	//dfslghdslkg
	//dlsfjghkdfjshg
	//dsflkgjdklsfj
	private void Awake()
	{
		if (Instance)
		{
			DestroyImmediate(this);
			return;
		}
		instance = this;
	}

	void Start () {
		Startup();
	}

	private void Startup()
	{
		Time.timeScale = 1;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		
		DataManager.Instance.LoadData();

		InitGameTimer();
		InitCheckPoints();

		InitiateCreationOfSquares();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			ScoreManager.Instance.FinalizeGame();
			Exit();
		}
	}

	private void InitiateCreationOfSquares()
	{
		for (Positions position = Positions.Top; position <= Positions.Bottom; position++)
		{
			SquareFactory.Instance.CreateSquare(position);
		}
	}

	public void FinalizeGame()
	{
		Time.timeScale = 0;
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

	public bool ColorHasPairOnTheField(Color color)
	{
		var result = DataManager.Instance.ColorIsUsedForCheckPoints(color);
		return result;
	}
}
