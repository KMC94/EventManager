//-------------------------------------------------
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//-------------------------------------------------
public class Enums : MonoBehaviour
{
	//-------------------------------------------------
	void Update()
	{
		//Press space to list all wizards in scene
		if(Input.GetKeyDown(KeyCode.Space))
		{
			//Get first wizard through static member
			Wizard Wizards = Wizard.FirstCreated;

			//If there is at least one wizard, then loop them all
			if(Wizard.FirstCreated != null)
			{
				//Loop through all wizards in foreach
				foreach(Wizard W in Wizards)
					Debug.Log (W.WizardName);
				
			}
		}
	}
	//-------------------------------------------------
}
//-------------------------------------------------