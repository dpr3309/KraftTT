using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CheckPoint : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;

	private Color color;
	public Color CurrentColor
	{
		get { return color; }
	}

	void Awake()
	{
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		GameManager.InitCheckPoints += SetColor;
		
	}

	private void SetColor()
	{
		color = DataManager.Instance.GetCheckpointColor();
		spriteRenderer.color = color;
	}


	public void ChangeColor()
	{
		DataManager.Instance.AddReleasedCheckpointColor(color);
		SetColor();
	}
}
