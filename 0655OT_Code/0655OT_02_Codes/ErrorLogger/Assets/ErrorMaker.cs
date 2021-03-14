//Will cause a divide by zero exception when space is pressed
using UnityEngine;
using System.Collections;

public class ErrorMaker : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			int x = 0;
			int y = 5 / x;
		}
	}
}
