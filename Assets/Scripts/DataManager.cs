using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

	private static DataManager instance = null;

	public static DataManager Instance
	{
		get { return instance; }
	}

	private void Awake()
	{
		if (Instance)
		{
			DestroyImmediate(this);
			return;
		}

		instance = this;
		DontDestroyOnLoad(this);
	}

	public void SetBestScore(int value)
	{
		PlayerPrefs.SetInt("BestScore", value);
	}

	public int GetBestScore()
	{
		var bestScore = PlayerPrefs.GetInt("BestScore", 0);
		return bestScore;
	}
}
