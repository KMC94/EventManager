//--------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
//--------------------------------------------------
public class TextFileAccess : MonoBehaviour
{
	//--------------------------------------------------
	//Function to load text data from external file
	public static string LoadTextFromFile(string Filename)
	{
		//If file does not exist on system, then return empty string
		if(!File.Exists(Filename)) return string.Empty;

		//File exists, now load text from file
		return File.ReadAllText(Filename);
	}
	//--------------------------------------------------
	//Function to load text data, line by line, into a string array
	public static string[] LoadTextAsLines(string Filename)
	{
		//If file does not exist on system, then return empty array
		if(!File.Exists(Filename)) return null;
	
		//Get lines
		return File.ReadAllLines(Filename);
	}
	//--------------------------------------------------
	//Function to read basic ini file to dictionary
	public static Dictionary<string, string> ReadINIFile(string Filename)
	{
		//If file does not exist on system, then return null
		if(!File.Exists(Filename)) return null;

		//Create new dictionary
		Dictionary<string, string> INIFile = new Dictionary<string, string>();

		//Create new stream reader
		using (StreamReader SR = new StreamReader(Filename))
		{
			//String for current line
			string Line;

			//Keep reading valid lines
			while(!string.IsNullOrEmpty(Line = SR.ReadLine()))
			{
				//Trim line of leading and trailing white space
				Line.Trim();

				//Split the line at key=value
				string[] Parts = Line.Split(new char[] {'='});

				//Now add to dictionary
				INIFile.Add(Parts[0].Trim(), Parts[1].Trim());
			}
		}

		//Return dictionary
		return INIFile;
	}
	//--------------------------------------------------
	//Function to load a string array from a CSV file
	public static string[] LoadFromCSV(string Filename)
	{
		//If file does not exist on system, then return null
		if(!File.Exists(Filename)) return null;

		//Get all text
		string AllText = File.ReadAllText(Filename);

		//Return string array
		return AllText.Split(new char[] {','});
	}
	//--------------------------------------------------
	//Gets text from the web in a string
	public IEnumerator GetTextFromURL(string URL)
	{
		//Create new WWW object
		WWW TXTSource = new WWW(URL);

		//Wait for data to load
		yield return TXTSource;

		//Now get text data
		string ReturnedText = TXTSource.text;
	}
	//--------------------------------------------------
}
//--------------------------------------------------