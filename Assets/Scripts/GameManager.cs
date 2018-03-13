using UnityEngine;

public class GameManager : MonoBehaviour {

	
	
	void Start () {
		SquareController.ReachedCheckpoint += ReachedCheckpoint;
		
	}

	private void ReachedCheckpoint(int point)
	{
		ScoreManager.Instance.AddPoint(point);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
