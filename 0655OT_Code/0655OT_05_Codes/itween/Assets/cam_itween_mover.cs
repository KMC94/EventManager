using UnityEngine;
using System.Collections;

public class cam_itween_mover : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("Camera Fly") , "time", 4f, "easetype", iTween.EaseType.easeInOutSine));
	}
}
