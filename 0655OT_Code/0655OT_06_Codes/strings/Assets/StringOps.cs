using UnityEngine;
using System.Collections;
//-------------------------------------------------------------
public static class StringExtensions {
	public static bool IsNullOrWhitespace(this string s){
		return s == null || s.Trim().Length == 0;
	}
}
//-------------------------------------------------------------
public class StringOps : MonoBehaviour 
{
	//-------------------------------------------------------------
	//Validate string
	public bool IsValid(string MyString)
	{
		//Check for null or white space
		if(MyString.IsNullOrWhitespace()) return false;

		//Now validate further
		return true;
	}
	//-------------------------------------------------------------
	//Compare strings
	public bool IsSame(string Str1, string Str2)
	{
		//Ignore case
		return string.Equals(Str1, Str2, System.StringComparison.CurrentCultureIgnoreCase);
	}
	//-------------------------------------------------------------
	//Sort comparision
	public int StringOrder (string Str1, string Str2)
	{
		//Ignores case
		return string.Compare(Str1, Str2, System.StringComparison.CurrentCultureIgnoreCase);
	}

	//-------------------------------------------------------------
	//Compare strings as hash
	public bool StringHashCompare(string Str1, string Str2)
	{
		int Hash1 = Animator.StringToHash(Str1);
		int Hash2 = Animator.StringToHash(Str2);

		return Hash1 == Hash2;
	}
	//-------------------------------------------------------------
	//Construct string from three numbers
	public void BuildString(int Num1, int Num2, float Num3)
	{
		string Output = string.Format("Number 1 is: {0}, Number 2 is: {1}, Number 3 is: {2}", Num1, Num2, Num3);

		Debug.Log (Output);
	}
	//-------------------------------------------------------------
	//Loops through string in foreach
	public void LoopLettersForEach(string Str)
	{
		//For each letter
		foreach(char C in Str)
		{
			//Print letter to console
			Debug.Log (C);
		}
	}
	//-------------------------------------------------------------
	//Loop through string as iterator
	public void LoopLettersEnumerator(string Str)
	{
		//Get Enumerator
		IEnumerator StrEnum = Str.GetEnumerator();

		//Move to next letter
		while(StrEnum.MoveNext())
		{
			Debug.Log ((char)StrEnum.Current);
		}
	}
	//-------------------------------------------------------------
	//Searches string for a specified word and returns found index of first occurrence
	public int SearchString(string LargerStr, string SearchStr)
	{
		//Ignore case
		return LargerStr.IndexOf(SearchStr, System.StringComparison.CurrentCultureIgnoreCase);
	}
	//-------------------------------------------------------------
}
//-------------------------------------------------------------