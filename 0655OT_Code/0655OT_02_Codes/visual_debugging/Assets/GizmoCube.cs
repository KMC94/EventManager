﻿using UnityEngine;
using System.Collections;

public class GizmoCube : MonoBehaviour
{
	//Show debugging info?
	public bool DrawGizmos = true;
	
	//Called to draw gizmos. Will always draw.
	//If you want to draw gizmos for only selected object, then call
	//OnDrawGizmosSelected
	void OnDrawGizmos() 
	{
		if(!DrawGizmos) return;
		
		//Set gizmo color
		Gizmos.color = Color.blue;
		
		//Draw front vector - show the direction I'm facing
		Gizmos.DrawRay(transform.position, transform.forward.normalized *  4.0f);
		
		//Set gizmo color
		//Show proximity radius around cube
		//If cube were an enemy, they would detect the player within this radius
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, 4.0f);
		
		//Restore color back to white
		Gizmos.color = Color.white;
	}
}