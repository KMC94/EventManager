using UnityEngine;
using System.Collections;
//------------------------------------------------------
//Sample class - can be attached to object as a component
public class Database : MonoBehaviour 
{
	//------------------------------------------------------
	//Public property for private variable iMyNumber
	//This is a public interface to the variable iMyNumber
	public int MyNumber
	{
		//Called when retrieving value
		get
		{
			return iMyNumber; //Output iMyNumber
		}
		
		//Called when setting value
		set
		{
			//If value is between 1-10 then change number, else ignore
			if(value >= 1 && value <= 10)
			{
				//Update private variable
				iMyNumber = value;
				
				//Call event
				NumberChanged();
			}
		}
	}
	//------------------------------------------------------
	//Internal reference a number between 1-10
	private int iMyNumber = 0;
	//------------------------------------------------------
	// Use this for initialization
	void Start () 
	{
		//Set MyNumber
		MyNumber = 11; //Will fail because number is > 10
		
		//Set MyNumber
		MyNumber = 7; //Will succeed because number is between 1-10
	}
	//------------------------------------------------------
	//Event called when iMyNumber is changed
	void NumberChanged()
	{
		Debug.Log("Variable iMyNumber changed to : " + iMyNumber.ToString());
	}
	//------------------------------------------------------
}
//------------------------------------------------------
