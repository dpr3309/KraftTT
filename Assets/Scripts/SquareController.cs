using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class SquareController : MonoBehaviour
{
	public static UnityAction<int> ReachedCheckpoint = delegate {  };

	private SpriteRenderer spriteRenderer;
	
	private Vector3 startPosition;

	private int reward = 1;
	[SerializeField]private Color color;

	private void Awake()
	{
		spriteRenderer = this.GetComponent<SpriteRenderer>();
	}


	void Start ()
	{
		startPosition = this.transform.position;
		spriteRenderer.color = color;
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
			ReachedCheckpoint(reward);
			this.gameObject.SetActive(false);
		}
	}

	private void OnDisable()
	{
		//todo: освободить квадрат
		
	}

	private void OnDestroy()
	{
		ReachedCheckpoint = delegate {  };
	}
}
