using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour 
{
	//Scene ID to change to
	public int DestScene = 0;
	
	// Update is called once per frame
	void Update () 
	{
		//Press N to move to next scene
		if(Input.GetKeyDown(KeyCode.N))
		{
			Application.LoadLevel(DestScene);
		}
	}
}
