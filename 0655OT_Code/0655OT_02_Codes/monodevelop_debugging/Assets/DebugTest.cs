using UnityEngine;
using System.Collections;

public class DebugTest : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		//Get all game objects in scene
		Transform[] Objs = Object.FindObjectsOfType<Transform>();

		//Cycle through all objects
		for(int i=0; i<Objs.Length; i++)
		{
			//Set object to world origin
			Objs[i].position = Vector3.zero;
		}

		//Enter Function 01
		Func01();
	}
	//-------------------------------------
	//Function calls func2
	void Func01()
	{
		Func02();
	}
	//-------------------------------------
	//Function calls func3
	void Func02()
	{
		Func03();
	}
	//-------------------------------------
	//Function prints message
	void Func03()
	{
		Debug.Log ("Entered Function 3");
	}
	//-------------------------------------
}