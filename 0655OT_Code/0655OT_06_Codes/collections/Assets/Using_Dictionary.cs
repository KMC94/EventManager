using UnityEngine;
using System.Collections;
using System.Collections.Generic; //Must include this for dictionaries

public class Using_Dictionary : MonoBehaviour 
{
	//Database of words. <Word, Score> key-value pair. The word itself, and its score for a word game
	public Dictionary<string, int> WordDatabase = new Dictionary<string, int>();

	// Use this for initialization
	void Start () 
	{
		//Create some words
		string[] Words = new string[5];
		Words[0]="hello";
		Words[1]="today";
		Words[2]="car";
		Words[3]="vehicle";
		Words[4]="computers";

		//add to dictionary with scores (score is based on word length)
		foreach(string Word in Words)
			WordDatabase.Add(Word, Word.Length);

		//Pick word from list using key value
		//Uses array syntax!
		Debug.Log ("Score is: " + WordDatabase["computers"].ToString());
	}
}