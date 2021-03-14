//----------------------------------------------
using UnityEngine;
using System.Collections;
//----------------------------------------------
public class ViewTester : MonoBehaviour 
{
	//----------------------------------------------
	void Update()
	{
		if(CamUtility.IsVisible(renderer, Camera.main))
		{
			Debug.Log ("Is visible");
		}
	}
}
//----------------------------------------------