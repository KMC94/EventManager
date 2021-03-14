using UnityEngine;
using System.Collections;

public class MyScriptFile : MonoBehaviour 
{
	//Array of game objects in the scene
	public GameObject[] MyObjects;
	
	// Use this for initialization
	void Start ()
	{
		//Build the array manually in code
		MyObjects = new GameObject[3];
		
		MyObjects[0] = Camera.main.gameObject; //Scene must have a camera tagged as MainCamera
		
		//Use GameObject.Find function to find objects in scene by name
		MyObjects[1] = GameObject.Find("Cube"); //Must have an object with this name
		MyObjects[2] = GameObject.Find("Cylinder"); //Must have an object with this name
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
}