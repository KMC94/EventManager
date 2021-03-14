//Class to fade from camera 0 to 1, and back from 1 to 0
//This class assumes there are only two scene cameras
//---------------------------------------
using UnityEngine;
using System.Collections;
//---------------------------------------
public class CameraFader : MonoBehaviour
{
	//---------------------------------------
	//Reference to cameras (all cameras in the scene to be composited)
	public Camera[] Cameras;

	//Reference to camera color (color to multiply with render)
	public Color[] CamCols = null;

	//Fade in/out time in seconds (total time for a fade in one direction)
	public float FadeTime = 2.0f;

	//Final material to apply to render (Can be used to apply a shader to final rendered pixels)
	public Material Mat = null;
	//---------------------------------------
	// Use this for initialization
	void Start () 
	{
		//Assign render textures to each camera
		foreach(Camera C in Cameras)
			C.targetTexture = new RenderTexture(Screen.width, Screen.height, 24); //Create texture
	}
	//---------------------------------------
	//This function is called once per frame after the camera has 
	//finished rendering but before the render is shown
	//It has a companion function OnPreRender (which is called before rendering)
	void OnPostRender()
	{
		//Define screen rect
		Rect ScreenRct = new Rect(0,0,Screen.width,Screen.height);

		//Source Rect
		Rect SourceRect = new Rect(0,1,1,-1);

		//Render each camera to their target texture
		for(int i = 0; i<Cameras.Length; i++)
		{
			//Render camera
			Cameras[i].Render();

			//Draw camera textures to screen using this camera
			GL.PushMatrix();
			GL.LoadPixelMatrix(); //Get pixel space matrix
			Graphics.DrawTexture(ScreenRct, Cameras[i].targetTexture, SourceRect, 0,0,0,0, CamCols[i]); //Draws each camera as layer
			GL.PopMatrix(); //Reset matrix
		}
	}
	//---------------------------------------
	//This function is called afer OnPostRender
	//And when final pixels are to be shown on screen
	//src = current render from camera
	//dst = texture to be shown on screen
	void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		//Frame finished rendering, now push final pixels to screen with Mat applied (can apply custom shader here)
		Graphics.Blit(src, dst, Mat);
	}
	//---------------------------------------
	//Function to lerp between color From to Color To over period TotalTime
	//This function is used to fade alpha for topmost rendered camera CamCols[1]
	public IEnumerator Fade(Color From, Color To, float TotalTime)
	{
		float ElapsedTime = 0f;

		//Loop while total time is not met
		while(ElapsedTime <= TotalTime)
		{
			//Update color
			CamCols[1] = Color.Lerp(From, To, ElapsedTime/TotalTime);

			//Wait until next frame
			yield return null;

			//Update Time
			ElapsedTime += Time.deltaTime;
		}

		//Apply final color
		CamCols[1] = Color.Lerp(From, To, 1f);
	}
	//---------------------------------------
	//Sample update function for testing camera functionality
	//Press space bar to fade in and out between cameras
	void Update()
	{
		//Fade camera in or out when space is pressed
		if(Input.GetKeyDown(KeyCode.Space))
		{
			StopAllCoroutines();

			//Should we fade out or in
			if(CamCols[1].a <= 0f)
				StartCoroutine(Fade(CamCols[1], new Color(0.5f,0.5f,0.5f,1f), FadeTime)); //Fade in
			else
				StartCoroutine(Fade(CamCols[1], new Color(0.5f,0.5f,0.5f,0f), FadeTime)); //Fade out
		}
	}
	//---------------------------------------
}
