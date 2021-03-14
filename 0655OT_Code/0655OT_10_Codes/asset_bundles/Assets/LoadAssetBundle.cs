using UnityEngine;
using System.Collections;

public class LoadAssetBundle : MonoBehaviour 
{
	//Mesh Renderer Reference
	private MeshRenderer MR = null;

	// Use this for initialization
	IEnumerator Start () 
	{
		//Get asset bundle file from local machine
		WWW www = new WWW (@"file:///c:\asset_textures.unity3d");

		//Wait until load is completed
		yield return www;

		//Retrieve texture from asset bundle
		Texture2D Tex = www.assetBundle.Load("texture_wood",typeof(Texture2D)) as Texture2D;

		//Assign texture in bundle to mesh
		MR = GetComponent<MeshRenderer>();
		MR.material.mainTexture = Tex;
	}
}
