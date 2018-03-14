using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{

	[SerializeField] private AppConfig config = new AppConfig();
	
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

	[SerializeField]private List<Color> UnusedCheckpointColors;
	[SerializeField]private List<Color> UnusedSquareColors;
	public void LoadData()
	{
		UnusedCheckpointColors = new List<Color>();
		UnusedSquareColors = new List<Color>();
		config = BinarySerializationManager.RuntimeLoadFile();

		InitListsOfColors();
	}

	private void InitListsOfColors()
	{
		Color color;
		for (int i = 0; i < config.ColorsCount; i++)
		{
			color = config[i];
			UnusedCheckpointColors.Add(color);
			UnusedSquareColors.Add(color);
		}
	}

	public Color GetCheckpointColor()
	{
		//todo: из массива свободных цветов для чекпоинтов получить цвет
		int index = Random.Range(0, UnusedCheckpointColors.Count);
		var color = UnusedCheckpointColors[index];
		UnusedCheckpointColors.Remove(color);
		return color;
	}
	
	public void AddReleasedCheckpointColor(Color color)
	{
		UnusedCheckpointColors.Add(color);
	}

	public Color GetSquareColor()
	{
		int index = Random.Range(0, UnusedSquareColors.Count);
		var color = UnusedSquareColors[index];
		UnusedSquareColors.Remove(color);
		return color;
	}
	
	public void AddReleasedSquareColor(Color color)
	{
		UnusedSquareColors.Add(color);
	}

	public int GetGameTimer()
	{
		return config.Timer;
	}

	
	
}
