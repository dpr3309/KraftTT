using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	[SerializeField] private Text currentScoreLable, bestScoreLable;
	private int currentScore, bestScore;

	private static ScoreManager instance;
	public static ScoreManager Instance
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
	}

	void Start ()
	{
		LoadBestScore();
	}

	private void LoadBestScore()
	{
		//todo: загрузить лучший счет
		UpdateBestScoreLable();
	}

	public void AddPoint(int point)
	{
		currentScore += point;
		if (currentScore > bestScore)
		{
			bestScore = currentScore;
			UpdateBestScoreLable();
		}

		UpdateCurrentScoreLable();
	}

	private void UpdateCurrentScoreLable()
	{
		currentScoreLable.text = currentScore.ToString();
	}

	private void UpdateBestScoreLable()
	{
		bestScoreLable.text = bestScore.ToString();
	}
}
