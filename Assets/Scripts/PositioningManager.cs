using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PositioningManager : MonoBehaviour
{
	[SerializeField]private float camHalfWidth, camHalfHeight;

	private static PositioningManager instance;

	public static PositioningManager Instance
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
		camHalfHeight = Camera.main.orthographicSize;
		camHalfWidth = Camera.main.aspect * camHalfHeight;
	}

	// Use this for initialization
	void Start () {
		

		
	}

	private Vector3 newPosition;
	private Vector2 offsetVector;
	public Vector3 CalculatePositionInCurrentCameraSize(Positions position, Sides side, Bounds bounds, Vector2 offset)
	{
		offsetVector = new Vector2(camHalfWidth*offset.x, camHalfHeight * offset.y);
		newPosition = new Vector3(0 + Camera.main.transform.position.x, 0 + Camera.main.transform.position.y);
		switch (position)
		{
			case Positions.Top:
				switch (side)
				{
					case Sides.Left:
						newPosition +=new Vector3(-camHalfWidth, camHalfHeight, 0);
						newPosition +=new Vector3((bounds.size.x / 2)+offsetVector.x, -(bounds.size.y / 2)-offsetVector.y, 0);
						break;
					case Sides.Centre:
						newPosition += new Vector3(0,camHalfHeight,0);
						newPosition +=new Vector3(0,-(bounds.size.y / 2)-offsetVector.y, 0);
						break;
					case Sides.Right:
						newPosition +=new Vector3(camHalfWidth, camHalfHeight, 0);
						newPosition +=new Vector3(-bounds.size.x / 2-offsetVector.x, -(bounds.size.y / 2)-offsetVector.y, 0);
						break;
					default:
						Debug.LogWarning("Тут еще одно позиционирование!!!");
						break;
				}
				
				break;
			
			case Positions.Middle:
				switch (side)
				{
					case Sides.Left:
						newPosition +=new Vector3(-camHalfWidth, 0, 0);
						newPosition -=new Vector3(-(bounds.size.x / 2)-offsetVector.x, 0, 0);
						break;
					case Sides.Centre:
						
						break;
					case Sides.Right:
						newPosition +=new Vector3(camHalfWidth, 0, 0);
						newPosition -=new Vector3((bounds.size.x / 2)+offsetVector.x, 0, 0);
						break;
					default:
						Debug.LogWarning("Тут еще одно позиционирование!!!");
						break;
				}
				break;
			
			case Positions.Bottom:
				switch (side)
				{
					case Sides.Left:
						newPosition +=new Vector3(-camHalfWidth, -camHalfHeight, 0);
						newPosition -=new Vector3(-(bounds.size.x / 2)-offsetVector.x, -(bounds.size.y / 2)-offsetVector.y, 0);
						break;
					case Sides.Centre:
						newPosition += new Vector3(0,-camHalfHeight,0);
						newPosition -=new Vector3(0,-(bounds.size.y / 2)-offsetVector.y, 0);
						break;
					case Sides.Right:
						newPosition +=new Vector3(camHalfWidth, -camHalfHeight, 0);
						newPosition -=new Vector3((bounds.size.x / 2)+offsetVector.x, -(bounds.size.y / 2)-offsetVector.y, 0);
						break;
					default:
						Debug.LogWarning("Тут еще одно позиционирование!!!");
						break;
				}
				break;
				
		}

		return newPosition;
	}


}
