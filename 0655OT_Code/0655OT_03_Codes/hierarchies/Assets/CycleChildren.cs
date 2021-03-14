using UnityEngine;
using System.Collections;
//------------------------------------------
public class CycleChildren : MonoBehaviour 
{
	//------------------------------------------
	// Use this for initialization
	void Start () 
	{
		//Cycle though children of this object
		for(int i=0; i<transform.childCount; i++)
		{
			//Print name of child to console
			Debug.Log (transform.GetChild(i).name);
		}
	}
	//------------------------------------------
}
//------------------------------------------