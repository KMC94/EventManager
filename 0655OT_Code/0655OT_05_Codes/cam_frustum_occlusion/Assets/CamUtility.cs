using UnityEngine;
using System.Collections;
//---------------------------------------------------------
public class CamUtility
{
	//---------------------------------------------------------
	//Function to determine whether a renderer is within frustum of a specified camera
	//Returns true if renderer is within frustum, else false
	public static bool IsRendererInFrustum(Renderer Renderable, Camera Cam)
	{
		//Construct frustum planes from camera
		//Each plane represents one wall of frustrum
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Cam);

		//Test whether renderable is within frustum planes
		return GeometryUtility.TestPlanesAABB(planes, Renderable.bounds);
	}
	//---------------------------------------------------------
	//Function to determine whether a point in the scene is within frustum of a specified camera
	//Returns true if point is within frustum, else false
	//The out param ViewPortLoc defines the location of the point on screen, if function returns true
	public static bool IsPointInFrustum(Vector3 Point, Camera Cam, out Vector3 ViewPortLoc)
	{
		//Create new bounds with no size
		Bounds B = new Bounds(Point, Vector3.zero);

		//Construct frustum planes from camera
		//Each plane represents one wall of frustrum
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Cam);

		//Test whether point is within frustum planes
		bool IsVisible = GeometryUtility.TestPlanesAABB(planes, B);

		//Assign viewport location
		ViewPortLoc = Vector3.zero;

		//If visible then get viewport location of point
		if(IsVisible)
			ViewPortLoc = Cam.WorldToViewportPoint(Point);
	
		return IsVisible;
	}
	//---------------------------------------------------------
	//Function to determine whether an object is visible (in frustum and has unbroken line to camera)
	public static bool IsVisible(Renderer Renderable, Camera Cam)
	{
		//If in frustrum then cast line
		if(CamUtility.IsRendererInFrustum(Renderable, Cam))
			return !Physics.Linecast(Renderable.transform.position, Cam.transform.position); //Is direct line between camera and object?

		return false; //No line found or not in frustum
	}
	//---------------------------------------------------------
}
