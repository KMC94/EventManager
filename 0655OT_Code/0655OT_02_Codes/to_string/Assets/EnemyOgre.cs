using UnityEngine;
using System.Collections;
//--------------------------------------------
//Sample enemy Ogre class
public class EnemyOgre : MonoBehaviour 
{
	//--------------------------------------------
	//Attack types for OGRE
	public enum AttackType {PUNCH, MAGIC, SWORD, SPEAR};
	
	//Current attack type being used
	public AttackType CurrentAttack = AttackType.PUNCH;
	
	//Health
	public int Health = 100;
	
	//Recovery Delay (after attacking)
	public float RecoveryTime = 1.0f;
	
	//Movement speed of Ogre - metres per second
	public float Speed = 1.0f;
	
	//Name of Ogre
	public string OgreName = "Harry";
	//--------------------------------------------
	//Override ToString method
	public override string ToString ()
	{
		//Return a string representing the class
		return string.Format ("***Class EnemyOgre*** OgreName: {0} | Health: {1} | Speed: {2} | CurrentAttack: {3} | RecoveryTime: {4}", 
		                      OgreName, Health, Speed, CurrentAttack, RecoveryTime);
	}
	//--------------------------------------------
	void Start()
	{
		//Test line to convert object to string. Can delete this after testing
		Debug.Log (ToString());
	}
	//--------------------------------------------
}
//--------------------------------------------