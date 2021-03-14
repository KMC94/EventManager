using UnityEngine;
using System.Collections;

public class MouseTest : MonoBehaviour 
{
	void OnMouseEnter()
	{
		Debug.Log ("Enter");
	}

	void OnMouseExit()
	{
		Debug.Log ("Exit");
	}

	void OnMouseDown()
	{
		Debug.Log ("Down");
	}

	void OnMouseUp()
	{
		Debug.Log ("Up");
	}
}
