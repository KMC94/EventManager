//-----------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml; 
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
//-----------------------------------------------
public class ObjSerializer : MonoBehaviour
{
	//Data to save to file XML or Binary
	[System.Serializable]
	[XmlRoot("GameData")]
	public class MySaveData
	{
		//Transform data to save/load to and from file
		//This represents a conversion of a transform object
		//into simpler values, like floats
		[System.Serializable]
		public struct DataTransform
		{
			public float X;
			public float Y;
			public float Z;
			public float RotX;
			public float RotY;
			public float RotZ;
			public float ScaleX;
			public float ScaleY;
			public float ScaleZ;
		}

		//Transform object to save
		public DataTransform MyTransform = new DataTransform();
	}

	//My Save Data Object declared here
	public MySaveData MyData = new MySaveData();
	//-----------------------------------------------
	//Populate structure MyData with transform data
	//This is the data to be saved to a file
	private void GetTransform()
	{
		//Get transform component on this object
		Transform ThisTransform = transform;

		//We got the transform component, now fill data structure
		MyData.MyTransform.X = ThisTransform.position.x;
		MyData.MyTransform.Y = ThisTransform.position.y;
		MyData.MyTransform.Z = ThisTransform.position.z;
		MyData.MyTransform.RotX = ThisTransform.localRotation.eulerAngles.x;
		MyData.MyTransform.RotY = ThisTransform.localRotation.eulerAngles.y;
		MyData.MyTransform.RotZ = ThisTransform.localRotation.eulerAngles.z;
		MyData.MyTransform.ScaleX = ThisTransform.localScale.x;
		MyData.MyTransform.ScaleY = ThisTransform.localScale.y;
		MyData.MyTransform.ScaleZ = ThisTransform.localScale.z;
	}
	//-----------------------------------------------
	//Restore the transform component with loaded data
	//Call this function after loading data back from a file for restore
	private void SetTransform()
	{
		//Get transform component on this object
		Transform ThisTransform = transform;

		//We got the transform component, now restore data
		ThisTransform.position = new Vector3(MyData.MyTransform.X, MyData.MyTransform.Y, MyData.MyTransform.Z);
		ThisTransform.rotation = Quaternion.Euler(MyData.MyTransform.RotX, MyData.MyTransform.RotY, MyData.MyTransform.RotZ);
		ThisTransform.localScale = new Vector3(MyData.MyTransform.ScaleX, MyData.MyTransform.ScaleY, MyData.MyTransform.ScaleZ);
	}
	//-----------------------------------------------
	//Saves game data to XML file
	//Call this function to save data to an XML file
	//Call as Save(Application.persistentDataPath + "/Mydata.xml");
	public void SaveXML(string FileName = "GameData.xml")
	{
		//Get transform data
		GetTransform();

		//Now save game data
		XmlSerializer Serializer = new XmlSerializer(typeof(MySaveData));
		FileStream Stream = new FileStream(FileName, FileMode.Create);
		Serializer.Serialize(Stream, MyData);
		Stream.Close();
	}
	//-----------------------------------------------	
	//Load game data from XML file
	//Call this function to load data from an XML file
	//Call as Save(Application.persistentDataPath + "/Mydata.xml");
	public void LoadXML(string FileName = "GameData.xml")
	{
		//If file doesn't exist, then exit
		if(!File.Exists(FileName)) return;

		XmlSerializer Serializer = new XmlSerializer(typeof(MySaveData));
		FileStream Stream = new FileStream(FileName, FileMode.Open);
		MyData = Serializer.Deserialize(Stream) as MySaveData;
		Stream.Close();

		//Set transform - load back from a file
		SetTransform();
	}
	//-----------------------------------------------
	public void SaveBinary(string FileName = "GameData.sav")
	{
		//Get transform data
		GetTransform();

		BinaryFormatter bf = new BinaryFormatter();
		FileStream Stream = File.Create(FileName);
		bf.Serialize(Stream, MyData);
		Stream.Close();
	}
	//-----------------------------------------------
	public void LoadBinary(string FileName = "GameData.sav")
	{
		//If file doesn't exist, then exit
		if(!File.Exists(FileName)) return;

		BinaryFormatter bf = new BinaryFormatter();
		FileStream Stream = File.Open(FileName, FileMode.Open);
		MyData = bf.Deserialize(Stream) as MySaveData;
		Stream.Close();

		//Set transform - load back from a file
		SetTransform();
	}
	//-----------------------------------------------
	void Update()
	{
		//If 1 key is pressed,then data saved to XML file 
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			SaveXML(Application.persistentDataPath + "/Mydata.xml");
			Debug.Log ("Saved to: " + Application.persistentDataPath + "/Mydata.xml");
		}

		//If 2 key is pressed,then data loaded from XML file 
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			LoadXML(Application.persistentDataPath + "/Mydata.xml");
			Debug.Log ("Loaded from: " + Application.persistentDataPath + "/Mydata.xml");
		}

		//If 3 key is pressed,then data saved to binary file 
		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			SaveBinary(Application.persistentDataPath + "/Mydata.sav");
			Debug.Log ("Saved to: " + Application.persistentDataPath + "/Mydata.sav");
		}
		
		//If 4 key is pressed,then data loaded from binary file 
		if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			LoadBinary(Application.persistentDataPath + "/Mydata.sav");
			Debug.Log ("Loaded from: " + Application.persistentDataPath + "/Mydata.sav");
		}
	}
	//-----------------------------------------------
}
//-----------------------------------------------