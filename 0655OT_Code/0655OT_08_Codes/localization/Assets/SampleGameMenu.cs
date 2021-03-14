//----------------------------------------------
using UnityEngine;
using System.Collections;
//----------------------------------------------
public class SampleGameMenu : MonoBehaviour 
{
	[LocalizationTextAttribute("text_01")]
	public string NewGameText = string.Empty;

	[LocalizationTextAttribute("text_02")]
	public string LoadGameText = string.Empty;

	[LocalizationTextAttribute("text_03")]
	public string SaveGameText = string.Empty;

	[LocalizationTextAttribute("text_04")]
	public string ExitGameText = string.Empty;
}
//----------------------------------------------