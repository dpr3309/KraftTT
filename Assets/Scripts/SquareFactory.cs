using UnityEngine;

public class SquareFactory : MonoBehaviour
{
	private static SquareFactory instance;
	public static SquareFactory Instance
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

	[SerializeField] private GameObject squarePrefab;
	public void CreateSquare(Positions position)
	{
		var offset = new Vector2(0.1f, 0.1f);
		var bounds = squarePrefab.GetComponent<SpriteRenderer>().bounds;
		var startPosition =
			PositioningManager.Instance.CalculatePositionInCurrentCameraSize(position, Sides.Left, bounds, offset);
		Instantiate(squarePrefab, startPosition,Quaternion.identity);
	}
	
	public void CreateSquare(Vector3 position)
	{
		Instantiate(squarePrefab, position,Quaternion.identity);
	}
}
