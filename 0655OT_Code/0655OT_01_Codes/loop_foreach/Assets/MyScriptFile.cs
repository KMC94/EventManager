using UnityEngine;
using System.Collections;

public class MyScriptFile : MonoBehaviour 
{
	//Array of game objects in the scene
	public GameObject[] MyObjects;
	
	// Use this for initialization
	void Start ()
	{
		//Repeat code for all objects in array, one by one
		foreach(GameObject Obj in MyObjects)
		{
			//Destroy object
			DestroyImmediate(Obj);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
}