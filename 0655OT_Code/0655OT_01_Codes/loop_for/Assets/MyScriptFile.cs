using UnityEngine;
using System.Collections;

public class MyScriptFile : MonoBehaviour 
{
	//Array of game objects in the scene
	public GameObject[] MyObjects;
	
	// Use this for initialization
	void Start ()
	{
		//Repeat code backwards for all objects in array, one by one
		for(int i = MyObjects.Length-1; i >= 0; i--)
		{
			//Destroy object
			DestroyImmediate(MyObjects[i]);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
}