using UnityEngine;
using System.Collections;
//sample class to determine if a clear line or path exists between two objects
public class ObjectPath : MonoBehaviour 
{
	//Reference to sample enemy object
	public GameObject Enemy = null;

	//Layer mask to limit line detection
	public LayerMask LM;
	//----------------------------------------------------
	// Update is called once per frame
	void Update ()
	{
		//Check if clear path between objects
		if(!Physics.Linecast(transform.position, Enemy.transform.position, LM))
		{
			//There is clear path
			Debug.Log ("Path clear");
		}
	}
	//----------------------------------------------------
	//Show helper debug line in viewport
	void OnDrawGizmos()
	{
		Gizmos.DrawLine(transform.position, Enemy.transform.position);
	}
	//----------------------------------------------------
}