using UnityEngine;
using System.Collections;

public class MyScriptFile : MonoBehaviour 
{
	//Define possible states for enemy using an enum
	public enum EnemyState {CHASE, FLEE, FIGHT, HIDE};
	
	//The current state of enemy
	public EnemyState ActiveState = EnemyState.CHASE;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Check the ActiveState variable
		switch(ActiveState)
		{
		case EnemyState.FIGHT:
		{
			//Perform flee code here
			Debug.Log ("Entered fight state");
		}
			break;
			
			
		case EnemyState.FLEE:
		case EnemyState.HIDE:
		{
			//Flee and hide performs the same behaviour
			Debug.Log ("Entered flee or hide state");
		}
			break;
			
		default:
		{
			//Default case when all other states fail
			//This is used for the chase state
			Debug.Log ("Entered chase state");
		}
			break;
		}
	}
}
