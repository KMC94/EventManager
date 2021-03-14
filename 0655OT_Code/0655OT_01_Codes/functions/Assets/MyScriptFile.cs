using UnityEngine;
using System.Collections;

public class MyScriptFile : MonoBehaviour 
{
	//Private variable for score
	//Accessible only within this class
	private int Score = 0;
	
	// Use this for initialization
	void Start ()
	{
		//Call update score
		UpdateScore(5, false); //Add five points
		UpdateScore (10, false); //Add ten points
		int CurrentScore = UpdateScore (15, false); //Add fifteen points and store result
		
		//Now double score
		UpdateScore(CurrentScore);
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	//Update game score
	public int UpdateScore (int AmountToAdd, bool PrintToConsole = true)
	{
		//Add points to score
		Score += AmountToAdd;
		
		//Should we print to console?
		if(PrintToConsole){Debug.Log ("Score is: " + Score.ToString());}
		
		//Output current score and exit function
		return Score;
	}
}