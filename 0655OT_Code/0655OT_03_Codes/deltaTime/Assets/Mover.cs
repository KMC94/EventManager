using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour 
{
	//Speed of cube
	public float Speed = 1.0f;

	// Update is called once per frame
	void Update () 
	{
		//Move cube along forward direction by speed
		transform.localPosition += transform.forward * Speed * Time.deltaTime;
	}
}