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

	public void CreateSquare(Vector3 position)
	{
		Instantiate(squarePrefab, position,Quaternion.identity);
	}
}
