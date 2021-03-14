using UnityEngine;
using System.Collections;
//-------------------------------------------
//This object will survive scene changes
public class PersistentObj : MonoBehaviour 
{
	//-------------------------------------------
	// Use this for initialization
	void Start ()
	{
		//Make this object survive
		DontDestroyOnLoad(gameObject);
	}
}
//-------------------------------------------