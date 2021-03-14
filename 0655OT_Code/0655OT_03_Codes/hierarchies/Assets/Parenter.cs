using UnityEngine;
using System.Collections;
//----------------------------------------------------
public class Parenter : MonoBehaviour 
{
	//Reference to child object in scene
	private GameObject Child;
	//Reference to parent object in scene
	private GameObject Parent;
	//----------------------------------------------------
	// Use this for initialization
	void Start () 
	{
		//Get parent and child objects
		Child = GameObject.Find("Child");
		Parent = GameObject.Find("Parent");

		//Now parent them
		Child.transform.parent = Parent.transform;
	}
	//----------------------------------------------------
}
//----------------------------------------------------