//-------------------------------------------------------
using UnityEngine;
using System.Collections;
//Must include Regular Expression Namespace
using System.Text.RegularExpressions;
//-------------------------------------------------------
public class RGX : MonoBehaviour 
{
	//Regular Expression Search Pattern
	string search = "[dw]ay";

	//Larger string to search
	string txt = "hello, today is a good day to do things my way";

	// Use this for initialization
	void Start () 
	{
		//Perform search and get first result in m
		Match m = Regex.Match(txt, search);

		//While m refers to a search result, loop
		while(m.Success)
		{
			//Print result to console
			Debug.Log (m.Value);

			//Get next result, if any
			m = m.NextMatch();
		}
	}
}
//-------------------------------------------------------