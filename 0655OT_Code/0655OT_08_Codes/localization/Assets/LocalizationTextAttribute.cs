using UnityEngine;
using System.Collections;

//Attribute to attach to string objects
public class LocalizationTextAttribute : System.Attribute
{
	//ID to assign
	public string LocalizationID = string.Empty;

	//Constructor
	public LocalizationTextAttribute(string ID)
	{
		LocalizationID = ID;
	}
}
