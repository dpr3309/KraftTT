using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareController : MonoBehaviour
{

	[SerializeField] private Text lable;
	private Vector3 startPosition;
	
	// Use this for initialization
	void Start ()
	{
		startPosition = this.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown()
	{
		Debug.Log("Test");
		lable.text = "Test";
	}


	private Vector3 mousePosition;
	void OnMouseDrag()
	{
		mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		this.transform.position = new Vector3(mousePosition.x, mousePosition.y);

//		if (spring.enabled = true) 
//		{
// 
//			Vector2 cursorPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);//getting cursor position
//                 
//			spring.connectedAnchor = cursorPosition;//the anchor get's cursor's position
//                  
// 
//		}
	}
 
     
	void OnMouseUp()        
	{
     
		//spring.enabled = false;//disabling the spring component
		this.transform.position = startPosition;
	}
}
