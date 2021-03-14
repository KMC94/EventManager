using UnityEngine;
using System.Collections;

public class ErrorScript : MonoBehaviour 
{
	int MyNumber = 5;
	
	// Use this for initialization
	void Start () {
		
		MyNumber = 7;
	}
	
	// Update is called once per frame
	void Update () {
		MyNumber = 10;
	}
}