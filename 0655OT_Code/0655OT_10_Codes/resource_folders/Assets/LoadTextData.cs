using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//---------------------------------------------
public class LoadTextData : MonoBehaviour 
{
	//Reference to UI Text Component
	private Text MyText = null;

	//Reference to text asset in resources folder
	private TextAsset TextData = null;
	//---------------------------------------------
	// Use this for initialization
	void Awake () {
		//Get Text Component
		MyText = GetComponent<Text>();

		//Load text data from resources folder
		TextData = Resources.Load("TextData") as TextAsset;
	}
	//---------------------------------------------
	// Update is called once per frame
	void Update () {
		//Update text label component
		MyText.text = TextData.text;
	}
	//---------------------------------------------
}
//---------------------------------------------
