//CLASS TO SCROLL TEXTURE ON PLANE. CAN BE USED FOR MOVING SKY
//------------------------------------------------
using UnityEngine;
using System.Collections;
//------------------------------------------------
[RequireComponent (typeof (MeshRenderer))] //Requires Renderer Filter Component
public class MatScroller : MonoBehaviour
{
	//Public variables
	//------------------------------------------------
	//Reference to Horizontal Scroll Speed
	public float HorizSpeed = 1.0f;
	
	//Reference to Vertical Scroll Speed
	public float VertSpeed = 1.0f;
	
	//Reference to Min and Max Horiz and Vertical UVs to scroll between
	public float HorizUVMin = 1.0f;
	public float HorizUVMax = 2.0f;
	
	public float VertUVMin = 1.0f;
	public float VertUVMax = 2.0f;
	
	//Private variables
	//------------------------------------------------
	//Reference to Mesh Renderer Component
	private MeshRenderer MeshR = null;

	//Methods
	//------------------------------------------------
	// Use this for initialization
	void Awake ()
	{
		//Get Mesh Renderer Component
		MeshR = GetComponent<MeshRenderer>();
	}
	//------------------------------------------------
	// Update is called once per frame
	void Update () 
	{
		//Scrolls texture between min and max
		Vector2 Offset = new Vector2((MeshR.material.mainTextureOffset.x > HorizUVMax) ? HorizUVMin : MeshR.material.mainTextureOffset.x + Time.deltaTime * HorizSpeed,
									 (MeshR.material.mainTextureOffset.y > VertUVMax) ? VertUVMin : MeshR.material.mainTextureOffset.y + Time.deltaTime * VertSpeed);
		
		//Update UV coordinates
		MeshR.material.mainTextureOffset = Offset;
	}
	//------------------------------------------------
}
//------------------------------------------------
