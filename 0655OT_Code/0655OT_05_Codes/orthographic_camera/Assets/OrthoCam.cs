//-------------------------------------------------------
using UnityEngine;
using System.Collections;
//-------------------------------------------------------
[RequireComponent(typeof(Camera))] //Requires camera component to work
//-------------------------------------------------------
public class OrthoCam : MonoBehaviour
{
	//private reference to camera component
	private Camera Cam = null;

	//Reference to Pixels to World Units Scale
	public float PixelsToWorldUnits = 200f;
	//-------------------------------------------------------
	// Use this for initialization
	void Awake () 
	{
		//Get camera reference
		Cam = GetComponent<Camera>();
	}
	//-------------------------------------------------------
	// Update is called once per frame
	void LateUpdate () 
	{
		//Update orthographic size
		Cam.orthographicSize = Screen.height / 2f / PixelsToWorldUnits;
	}
	//-------------------------------------------------------
}
//-------------------------------------------------------