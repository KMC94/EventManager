//-----------------------------------------------------------
using UnityEngine;
using System.Collections;
//-----------------------------------------------------------
public class TexturePainter : MonoBehaviour 
{
	//Square texture with alpha to use a brush graphic for painting
	public Texture2D BrushTexture = null;

	//Width and height of destination texture on which to paint
	public int SurfaceTextureWidth = 512;
	public int SurfaceTextureHeight = 512;

	//Reference to painting surface texture
	public Texture2D SurfaceTexture = null;

	//Reference to material to which destination texture will be applied
	public Material DestMat = null;
	//-----------------------------------------------------------
	// Use this for initialization
	void Start () 
	{
		//Create destination texture
		SurfaceTexture = new Texture2D(SurfaceTextureWidth, SurfaceTextureHeight, TextureFormat.RGBA32, false);

		//Fill with black pixels (transparent; alpha=0)
		Color[] Pixels = SurfaceTexture.GetPixels();
		for(int i=0; i<Pixels.Length; i++)
			Pixels[i] = new Color(0,0,0,0);
		SurfaceTexture.SetPixels(Pixels);
		SurfaceTexture.Apply();

		//Set as renderer main texture
		renderer.material.mainTexture = SurfaceTexture;

		//If there is a destination material, set blend texture as this one
		//This used in conjunction with a custom shader (See TexBlender.shader file)
		if(DestMat)
			DestMat.SetTexture("_BlendTex", SurfaceTexture);
	}
	//-----------------------------------------------------------
	// Update is called once per frame
	void Update () 
	{
		//If mouse button down, then start painting
		if(Input.GetMouseButtonDown(0))
		{
			//Get hit of mouse cursor
			RaycastHit hit;

			//Convert screen point to ray in scene
			if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
				return;

			//Get hit collder
			Renderer renderer = hit.collider.renderer;
			MeshCollider Collide = hit.collider as MeshCollider;
			if (renderer == null || renderer.sharedMaterial == null || renderer.sharedMaterial.mainTexture == null || Collide == null)
				return;

			//Get UV Coords of hit surface
			Vector2 pixelUV = hit.textureCoord;
			pixelUV.x *= renderer.material.mainTexture.width;
			pixelUV.y *= renderer.material.mainTexture.height;

			//Update coords to texture middle (align brush texture center to cursor)
			pixelUV.x -= BrushTexture.width/2;
			pixelUV.y -= BrushTexture.height/2;

			//Clamp pixel values between 0 and texture width
			pixelUV.x = Mathf.Clamp(pixelUV.x, 0, renderer.material.mainTexture.width);
			pixelUV.y = Mathf.Clamp(pixelUV.y, 0, renderer.material.mainTexture.height);

			//Paint onto destination texture
			PaintSourceToDestTexture(BrushTexture, renderer.material.mainTexture as Texture2D, (int)pixelUV.x, (int)pixelUV.y);
		}
	}
	//-----------------------------------------------------------
	//Paint source text to destination
	//Will paint a brush texture onto a destination texture at the specified pixel position (allowing for pixel clamp at texture edges)
	public static void PaintSourceToDestTexture(Texture2D Source, Texture2D Dest, int Left, int Top)
	{
		//Get source pixels
		Color[] SourcePixels = Source.GetPixels();

		//Get dest pixels
		Color[] DestPixels = Dest.GetPixels();

		for(int x=0; x<Source.width; x++)
		{
			for(int y=0; y<Source.height; y++)
			{
				//Get source pixel
				Color Pixel = GetPixelFromArray(SourcePixels, x, y, Source.width);

				//Get offset in destination
				int DestOffsetX = Left + x;
				int DestOffsetY = Top + y;

				if(DestOffsetX < Dest.width && DestOffsetY < Dest.height)
					SetPixelInArray(DestPixels, DestOffsetX, DestOffsetY, Dest.width, Pixel, true);
			}
		}

		//Update destination texture
		Dest.SetPixels(DestPixels);
		Dest.Apply();
	}
	//-----------------------------------------------------------
	//Reads color from pixel array
	public static Color GetPixelFromArray(Color[] Pixels, int X, int Y, int Width)
	{
		return Pixels[X+Y*Width];
	}
	//-----------------------------------------------------------
	//Sets color in pixel array
	public static void SetPixelInArray(Color[] Pixels, int X, int Y, int Width, Color NewColor, bool Blending=false)
	{
		if(!Blending)
			Pixels[X+Y*Width] = NewColor; //Replace color
		else
		{
			//Here we blend the color onto existing surface, preserving alpha transparency
			Color C = Pixels[X+Y*Width] * (1.0f - NewColor.a);
			Color Blend = NewColor * NewColor.a;

			Color Result = C + Blend;
			float Alpha = C.a + Blend.a;

			Pixels[X+Y*Width] = new Color(Result.r, Result.g, Result.b, Alpha);
		}
	}
	//-----------------------------------------------------------
}
//-----------------------------------------------------------
