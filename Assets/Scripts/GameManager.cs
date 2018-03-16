﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static UnityAction InitGameTimer = delegate {  };
	public static UnityAction InitCheckPoints = delegate {  };

	
	void Start () {
		Startup();
	}

	private void Startup()
	{
		Time.timeScale = 1;
		
		DataManager.Instance.LoadData();

		InitGameTimer();
		InitCheckPoints();

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
}
