using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CheckPoint : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;

	[SerializeField] private Color color;
	public Color CurrentColor
	{
		get { return color; }
	}

	void Awake()
	{
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		
	}

	private void Start()
	{
		spriteRenderer.color = color;
	}
}
