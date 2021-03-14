//----------------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Linq;
//----------------------------------------------------------
public class LINQCSV : MonoBehaviour 
{
	//----------------------------------------------------------
	// Use this for initialization
	void Start () 
	{
		//Generate female name
		//Regular Expression Search Pattern
		//Find all names prefixed with 'female:' but do not include the prefix in the results
		string search = @"(?<=\bfemale:)\w+\b";

		//CSV Data - names of characters
		string CSVData = "male:john,male:tom,male:bob,female:betty,female:jessica,male:dirk";

		//Perform regular expression to retrieve all names prefixed with female. Do not include the prefix 'female:' within the results
		string[] FemaleNames = (from Match m in Regex.Matches(CSVData, search)
		        select m.Groups[0].Value).ToArray();

		//Print all female names in results
		foreach(string S in FemaleNames)
			Debug.Log (S);

		//Now pick a random female name from collection
		string RandomFemaleName = FemaleNames[Random.Range(0, FemaleNames.Length)];
	}
	//----------------------------------------------------------
}
//----------------------------------------------------------