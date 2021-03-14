using UnityEngine;
using System.Collections;

public class params_class : MonoBehaviour 
{
	// Use this for initialization
	void Start () {
		Debug.Log (Sum(5,5,5,9,15));
	}

	public int Sum(params int[] Numbers)
	{
		int Answer = 0;

		for(int i=0; i<Numbers.Length; i++)
			Answer += Numbers[i];

		return Answer;
	}
}
