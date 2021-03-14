//Custom Editor class to expose global properties of a class
//----------------------------------------------
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Reflection;
//----------------------------------------------
[CustomPropertyDrawer(typeof(ClassWithProperties))]
public class PropertyLister : PropertyDrawer
{
	//Height of inspector panel
	float InspectorHeight = 0;

	//Height of single row in pixels
	float RowHeight = 15;

	//Spacing between rows
	float RowSpacing = 5;

	// Draw the property inside the given rect
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
	{
		EditorGUI.BeginProperty(position, label, property);

		//Get referenced object
		object o = property.serializedObject.targetObject;
		ClassWithProperties CP = o.GetType().GetField(property.name).GetValue(o) as ClassWithProperties;

		int indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		//Layout
		Rect LayoutRect = new Rect(position.x, position.y, position.width, RowHeight);

		//Find all properties for object
		foreach(var prop in typeof(ClassWithProperties).GetProperties(BindingFlags.Public | BindingFlags.Instance))
		{
			//If integer property
			if(prop.PropertyType.Equals(typeof(int)))
			{
				prop.SetValue(CP, EditorGUI.IntField(LayoutRect, prop.Name, (int)prop.GetValue(CP,null)), null);
				LayoutRect = new Rect(LayoutRect.x, LayoutRect.y + RowHeight+RowSpacing, LayoutRect.width, RowHeight);
			}

			//If float property
			if(prop.PropertyType.Equals(typeof(float)))
			{
				prop.SetValue(CP, EditorGUI.FloatField(LayoutRect, prop.Name, (float)prop.GetValue(CP,null)), null);
				LayoutRect = new Rect(LayoutRect.x, LayoutRect.y + RowHeight+RowSpacing, LayoutRect.width, RowHeight);
			}

			//If color property
			if(prop.PropertyType.Equals(typeof(Color)))
			{
				prop.SetValue(CP, EditorGUI.ColorField(LayoutRect, prop.Name, (Color)prop.GetValue(CP,null)), null);
				LayoutRect = new Rect(LayoutRect.x, LayoutRect.y + RowHeight+RowSpacing, LayoutRect.width, RowHeight);
			}
		}

		//Update inspector height
		InspectorHeight = LayoutRect.y-position.y;

		EditorGUI.indentLevel = indent;
		EditorGUI.EndProperty();
	}
	//----------------------------------------------
	//This function returns how high (in pixels) the field should be
	//This is to make sure the GUI controls will not overlap or overrun the controls below
	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		return InspectorHeight;
	}
	//----------------------------------------------
}
//----------------------------------------------