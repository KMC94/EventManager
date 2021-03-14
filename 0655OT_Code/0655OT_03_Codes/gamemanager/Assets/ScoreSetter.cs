using UnityEngine;
using System.Collections;
//-------------------------------------------
public class ScoreSetter : MonoBehaviour 
{
	//-------------------------------------------
	// Use this for initialization
	void Start () 
	{
		//Set score on GameManager
		GameManager.Instance.HighScore = 100;
	}
	//-------------------------------------------
}
//-------------------------------------------