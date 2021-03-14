//--------------------------------------------------
using UnityEngine;
using System.Collections;
//--------------------------------------------------
public class SkyBox : MonoBehaviour 
{
	//--------------------------------------------------
	//Camera to follow
	public Camera FollowCam = null;

	//Rotate Speed (Degrees per second)
	public float RotateSpeed = 10.0f;

	//Transform
	private Transform ThisTransform = null;
	//--------------------------------------------------
	// Use this for initialization
	void Awake () {
		ThisTransform = transform;
	}
	//--------------------------------------------------
	// Update is called once per frame
	void Update () {
		//Update position
		ThisTransform.position = FollowCam.transform.position;

		//Update rotation
		ThisTransform.Rotate(new Vector3(0,RotateSpeed * Time.deltaTime,0));
	}
	//--------------------------------------------------
}
//--------------------------------------------------