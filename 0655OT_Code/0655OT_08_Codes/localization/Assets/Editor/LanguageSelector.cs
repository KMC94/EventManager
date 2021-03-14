//-------------------------------------------
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Xml;
using System.Linq;
using System.Reflection;
//-------------------------------------------
public class LanguageSelector
{
	[MenuItem ("Localization/English")]
	public static void SelectEnglish()
	{
		LanguageSelector.SelectLanguage("english");
	}

	[MenuItem ("Localization/French")]
	public static void SelectFrench()
	{
		LanguageSelector.SelectLanguage("french");
	}

	[MenuItem ("Localization/Yoda")]
	public static void SelectYoda()
	{
		LanguageSelector.SelectLanguage("yoda");
	}

	public static void SelectLanguage(string LanguageName)
	{
		//Access XML Text File in Project
		TextAsset textAsset = Resources.Load("LocalText") as TextAsset;
	
		//Load text into XML Reader object
		XmlDocument xmlDoc = new XmlDocument();
		xmlDoc.LoadXml(textAsset.text);

		//Get language nodes
		XmlNode[] LanguageNodes = (from XmlNode Node in xmlDoc.GetElementsByTagName("language")
								   where Node.Attributes["id"].Value.ToString().Equals(LanguageName.ToLower())
		                           select Node).ToArray();

		//If no matching node found, then exit
		if(LanguageNodes.Length <= 0)
			return;

		//Get first node
		XmlNode LanguageNode = LanguageNodes[0];

		//Get text object
		SampleGameMenu GM = Object.FindObjectOfType<SampleGameMenu>() as SampleGameMenu;

		//Loop through child xml nodes
		foreach (XmlNode Child in LanguageNode.ChildNodes)
		{
			//Get text Id for this node
			string TextID = Child.Attributes["id"].Value;
			string LocalText = Child.InnerText;

			//Loop through all fields
			foreach(var field in GM.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy))
			{
				//If field is a string then is relevant
				if(field.FieldType == typeof(System.String))
				{
					//Get custom attributes for field
					System.Attribute[] attrs = field.GetCustomAttributes(true) as System.Attribute[];
					
					foreach (System.Attribute attr in attrs)
					{
						if(attr is LocalizationTextAttribute)
						{
							//We've found text that should be localized. Check if IDs match
							LocalizationTextAttribute LocalAttr = attr as LocalizationTextAttribute;

							if(LocalAttr.LocalizationID.Equals(TextID))
							{
								//id matches, now set value
								field.SetValue(GM, LocalText);
							}
						}
					}
				}
			}
		}
	}
}
//-------------------------------------------