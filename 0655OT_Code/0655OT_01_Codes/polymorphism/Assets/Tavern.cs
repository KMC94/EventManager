using UnityEngine;
using System.Collections;

public class Tavern : MonoBehaviour 
{
	//Array of NPCs in tavern
	public MyCharacter[] Characters = null;
	//-------------------------------------------------------
	// Use this for initialization
	void Start () {
		
		//New array - 5 NPCs in tavern
		Characters = new MyCharacter[5];
		
		//Add characters of different types to array MyCharacter
		Characters[0] = new ManCharacter();
		Characters[1] = new WomanCharacter();
		Characters[2] = new OrcCharacter();
		Characters[3] = new ManCharacter();
		Characters[4] = new WomanCharacter();
		
		//Now run enter tavern functionality
		EnterTavern();
	}
	//-------------------------------------------------------
	//Function when player enters Tavern
	public void EnterTavern()
	{
		//Everybody say greeting
		foreach(MyCharacter C in Characters)
		{
			//This will call SayGreeting in derived class
			//Polymorphism ensures derived class is accessible through base class reference
			C.SayGreeting();
		}
	}
	//-------------------------------------------------------
}