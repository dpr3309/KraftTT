using UnityEngine;

public class PositionController : MonoBehaviour
{
	[SerializeField] private Sides side;
	[SerializeField] private Positions position;
	[SerializeField] private Vector2 offset;
	[SerializeField] private Bounds bounds;

	void Start ()
	{
		bounds = GetComponent<SpriteRenderer>().bounds;
		transform.position = PositioningManager.Instance.CalculatePositionInCurrentCameraSize(position, side, bounds, offset);
	}
}
