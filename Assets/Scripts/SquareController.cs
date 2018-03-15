using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class SquareController : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;
	private Vector3 startPosition;
	private Color color;
	
	private int reward = 1;
	private static float downTime;
	private const float delayBetweenClicks = 0.3f;

	private void Awake()
	{
		spriteRenderer = this.GetComponent<SpriteRenderer>();
	}

	private void SetColor()
	{
		color = DataManager.Instance.GetSquareColor();
		spriteRenderer.color = color;
	}

	void Start ()
	{
		startPosition = this.transform.position;
		SetColor();
	}
	
	private void OnMouseDown()
	{
		if (Time.time - downTime < delayBetweenClicks)
		{
			if (!DataManager.Instance.ColorHasPairOnTheField(color))
			{
				FinalizeAndDestroy();
			}
		}
		downTime = Time.time;
	}


	private Vector3 mousePosition;
	void OnMouseDrag()
	{
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		this.transform.position = new Vector3(mousePosition.x, mousePosition.y);
	}
     
	void OnMouseUp()
	{
		ResetPosition();
	}

	private void ResetPosition()
	{
		this.transform.position = startPosition;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("CheckPoint"))
		{
			CheckComplianceCheckPoint(other);
		}
	}

	private void CheckComplianceCheckPoint(Collider2D other)
	{
		var checkPoint = other.gameObject.GetComponent<CheckPoint>();

		if (this.color == checkPoint.CurrentColor)
		{
			ScoreManager.Instance.AddPoint(reward);
			
			FinalizeAndDestroy();
		}
	}

	private void FinalizeAndDestroy()
	{
		DataManager.Instance.AddReleasedSquareColor(color);
		SquareFactory.Instance.CreateSquare(startPosition);
		Destroy(this.gameObject);
	}
}
