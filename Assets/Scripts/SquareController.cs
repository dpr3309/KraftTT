using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SquareController : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;
	private Vector3 startPosition;
	private Color color;
	private Transform transformComponent;
	
	private void Awake()
	{
		spriteRenderer = this.GetComponent<SpriteRenderer>();
		transformComponent = this.transform;
	}

	void Start ()
	{
		startPosition = transformComponent.position;
		SetColor();
	}
	
	private static float clickTime;
	private const float delayBetweenClicks = 0.3f;
	private void OnMouseDown()
	{
		if (Time.time - clickTime < delayBetweenClicks)
		{
			if (!GameManager.Instance.ColorHasPairOnTheField(color))
			{
				FinalizeAndDestroy();
			}
		}
		clickTime = Time.time;
	}

	private Vector3 mousePosition;
	void OnMouseDrag()
	{
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transformComponent.position = new Vector3(mousePosition.x, mousePosition.y);
	}
     
	void OnMouseUp()
	{
		ResetPosition();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("CheckPoint"))
		{
			CheckComplianceCheckPoint(other);
		}
	}
	
	private void SetColor()
	{
		color = DataManager.Instance.GetSquareColor();
		spriteRenderer.color = color;
	}
	
	private void ResetPosition()
	{
		transformComponent.position = startPosition;
	}

	private const int reward = 1;
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
