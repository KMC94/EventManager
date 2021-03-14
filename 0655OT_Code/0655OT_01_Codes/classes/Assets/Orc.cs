using UnityEngine;
using System.Collections;

public class Orc : MonoBehaviour 
{
	//Reference to the transform component of orc (position, rotation, scale)
	private Transform ThisTransform = null;
	
	//Enum for states of orc
	public enum OrcStates {NEUTRAL, ATTACK_MELEE, ATTACK_RANGE};
	
	//Current state of orc
	public OrcStates CurrentState = OrcStates.NEUTRAL;
	
	//Movement speed of orc in meters per second
	public float OrcSpeed = 10.0f;
	
	//Is orc friendly to player
	public bool isFriendly = false;
	
	//--------------------------------------------------
	// Use this for initialization
	void Start ()
	{
		//Get transform of orc
		ThisTransform = transform;
	}
	//--------------------------------------------------
	// Update is called once per frame
	void Update ()
	{
	}
	//--------------------------------------------------
	//State actions for orc
	public void AttackMelee()
	{
		//Do melee attack here
	}
	//--------------------------------------------------
	public void AttackRange()
	{
		//Do range attack here
	}
	//--------------------------------------------------
}