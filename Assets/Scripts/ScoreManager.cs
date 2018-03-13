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
		bestScore = DataManager.Instance.GetBestScore();
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

	public void FinalizeGame()
	{
		var oldBestScore = DataManager.Instance.GetBestScore();
		if (oldBestScore < currentScore)
		{
			DataManager.Instance.SetBestScore(currentScore);
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			Debug.Log("Reset score");
			DataManager.Instance.SetBestScore(0);
			UpdateBestScoreLable();
		}
	}
}
