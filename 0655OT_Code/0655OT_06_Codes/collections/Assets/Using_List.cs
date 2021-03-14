using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//----------------------------------------
//Sample enemy class for holding enemy data
[System.Serializable]
public class Enemy
{
	public int Health = 100;
	public int Damage = 10;
	public int Defense = 5;
	public int Mana = 20;
	public int ID = 0;

	public void MyFunc(){}
}
//----------------------------------------
public class Using_List : MonoBehaviour 
{
	//----------------------------------------
	//List of active enemies in the scene
	public List<Enemy> Enemies = new List<Enemy>();
	//----------------------------------------
	// Use this for initialization
	void Start () 
	{
		//Add 5 enemies to the list
		for(int i=0; i<5; i++)
			Enemies.Add (new Enemy()); //Add method inserts item to end of the list

		//Remove 1 enemy from start of list (index 0)
		Enemies.RemoveRange(0,1);

		//Iterate through list - this is how we loop through list
		foreach (Enemy E in Enemies)
		{
			//Print enemy ID
			Debug.Log (E.ID);
		}
	}
	//----------------------------------------
	//Function to remove all items from a loop while call a function on each object
	void RemoveAllItems()
	{
		//Traverse list backwards
		for(int i = Enemies.Count-1; i>=0; i--)
		{
			//Call function on enemy before removal
			Enemies[i].MyFunc();

			//Remove this enemy from list
			Enemies.RemoveAt(i);
		}
	}
	//----------------------------------------
	void Update()
	{
		//Press R to remove element
		if(Input.GetKeyDown(KeyCode.R))
		{
			RemoveAllItems();
		}
	}
	//----------------------------------------
}
//----------------------------------------