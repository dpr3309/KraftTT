using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	[SerializeField] private Text currentScoreLable, bestScoreLable;
	private int  bestScore;

	public int CurrentScore { get; private set;}

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
		CurrentScore += point;
		if (CurrentScore > bestScore)
		{
			bestScore = CurrentScore;
			UpdateBestScoreLable();
		}

		UpdateCurrentScoreLable();
	}

	private void UpdateCurrentScoreLable()
	{
		currentScoreLable.text = CurrentScore.ToString();
	}

	private void UpdateBestScoreLable()
	{
		bestScoreLable.text = bestScore.ToString();
	}

	public void FinalizeGame()
	{
		var oldBestScore = DataManager.Instance.GetBestScore();
		if (oldBestScore < CurrentScore)
		{
			DataManager.Instance.SetBestScore(CurrentScore);
		}
	}

	private void OnDestroy()
	{
		FinalizeGame();
	}

#if UNITY_EDITOR
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			Debug.Log("Reset score");
			DataManager.Instance.SetBestScore(0);
			UpdateBestScoreLable();
		}
	}
#endif
}
