using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class SquareController : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;
	
	private Vector3 startPosition;

	private int reward = 1;
	private Color color;

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

			DataManager.Instance.AddReleasedSquareColor(color);
			SquareFactory.Instance.CreateSquare(startPosition);
			Destroy(this.gameObject);

		}
	}
}
