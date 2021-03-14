//-------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//-------------------------------------------------
public class EnemyQuery : MonoBehaviour 
{
	//-------------------------------------------------
	//Get list of enemies matching search criteria
	public void FindEnemiesOldWay()
	{
		//Get all enemies in scene
		Enemy[] Enemies = Object.FindObjectsOfType<Enemy>();

		//Filtered Enemies
		List<Enemy> FilteredData = new List<Enemy>();

		//Loop through enemies and check
		foreach(Enemy E in Enemies)
		{
			if(E.Health <= 50 && E.Defense < 5)
			{
				//Found appropriate enemy
				FilteredData.Add (E);
			}
		}

		//Now we can process filtered data
		//All items in FilteredData match search criteria
		foreach(Enemy E in FilteredData)
		{
			//Process Enemy E
			Debug.Log (E.name);
		}
	}
	//-------------------------------------------------
	public void FindEnemiesLinqWay()
	{
		//Get all enemies in scene
		Enemy[] Enemies = Object.FindObjectsOfType<Enemy>();

		//Perform search
		Enemy[] FilteredData = (from EnemyChar in Enemies
			where EnemyChar.Health <= 50 && EnemyChar.Defense < 5
		                  select EnemyChar).ToArray();

		//Now we can process filtered data
		//All items in FilteredData match search criteria
		foreach(Enemy E in FilteredData)
		{
			//Process Enemy E
			Debug.Log (E.name);
		}
	}
	//-------------------------------------------------
}
//-------------------------------------------------