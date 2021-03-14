using UnityEngine;
using System.Collections;
//-------------------------------------------------
public class CamFieldView : MonoBehaviour 
{
	//-------------------------------------------------
	//Field of view (degrees) in which can see in front of us
	//Measure in degrees from forward vector (left or right)
	public float AngleView = 30.0f;
	
	//Target object for seeing
	public Transform Target = null;

	//Local transform
	private Transform ThisTransform = null;
	//-------------------------------------------------
	// Use this for initialization
	void Awake () 
	{
		//Get local transform
		ThisTransform = transform;
	}
	//-------------------------------------------------
	// Update is called once per frame
	void Update ()
	{
		//Update view between camera and target
		Vector3 Forward = ThisTransform.forward.normalized;
		Vector3 ToObject = (Target.position - ThisTransform.position).normalized;

		//Get Dot Product
		float DotProduct = Vector3.Dot(Forward, ToObject);
		float Angle = DotProduct * 180f;

		//Check within field of view
		if(Angle >= 180f-AngleView)
			Debug.Log ("Object can be seen");
	}
	//-------------------------------------------------
}
//-------------------------------------------------