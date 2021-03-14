using UnityEngine;
using System.Collections;

public class MyScriptFile : MonoBehaviour 
{
	// Use this for initialization
	void Start ()
	{
		//Will count how many messages have been printed
		int NumberOfMessages = 0;
		
		//Loop until 5 messages have been printed to the console
		while(NumberOfMessages < 5) //Have we printed 5 messages?
		{
			//Print message
			Debug.Log ("This is Message: " + NumberOfMessages.ToString());
			
			//Increment counter
			++NumberOfMessages;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
}