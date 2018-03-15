using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{

	[SerializeField] private Sides side;
	[SerializeField] private Positions position;
	[SerializeField] private Vector2 offset;
	[SerializeField] private Bounds bound;

	
	void Start ()
	{
		bound = GetComponent<SpriteRenderer>().bounds;
		transform.position = PositioningManager.Instance.CalculatePositionInCurrentCameraSize(position, side, bound, offset);

	}

	public void SetPosition(Sides _side, Positions _position)
	{
		transform.position = PositioningManager.Instance.CalculatePositionInCurrentCameraSize(_position, _side, bound, offset);
	}
	
	
}
