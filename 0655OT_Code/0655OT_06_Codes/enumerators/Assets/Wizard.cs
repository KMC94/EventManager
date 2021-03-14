using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//----------------------------------------------------
//Class derives from IEnumerator
//Handles bounds safe iteration of all wizards in scene
public class WizardEnumerator : IEnumerator
{
	//References the current wizard object pointed to by enumerator
	private Wizard CurrentObj = null;
	//----------------------------------------------------
	//Overrides movenext event - increments iterator to next wizard in sequence
	public bool MoveNext()
	{
		//Get next wizard
		CurrentObj = (CurrentObj==null) ? Wizard.FirstCreated : CurrentObj.NextWizard;
		
		//Return the next wizard
		return (CurrentObj != null);
	}
	//----------------------------------------------------
	//Resets the iterator back to the first wizard
	public void Reset()
	{
		CurrentObj = null;
	}
	//----------------------------------------------------
	//C# Property to get current wizard
	public object Current
	{
		get{return CurrentObj;}
	}
	//----------------------------------------------------
}
//----------------------------------------------------
//Sample class defining a wizard object
//Derives from IEnumerable, allowing looping with foreach
[System.Serializable]
public class Wizard : MonoBehaviour, IEnumerable
{
	//----------------------------------------------------
	//Reference to last created wizard
	public static Wizard LastCreated = null;
	
	//Reference to first created wizard
	public static Wizard FirstCreated = null;
	
	//Reference to next wizard in the list
	public Wizard NextWizard = null;
	
	//Reference to previous wizard in the list
	public Wizard PrevWizard = null;
	
	//Name of this wizard
	public string WizardName = "";
	//----------------------------------------------------
	//Constructor
	void Awake()
	{
		//Should we update first created
		if(FirstCreated==null)
			FirstCreated = this;
		
		//Should we update last created
		if(Wizard.LastCreated != null)
		{
			Wizard.LastCreated.NextWizard = this;
			PrevWizard = Wizard.LastCreated;
		}
		
		Wizard.LastCreated = this;
	}
	//----------------------------------------------------
	//Called on object destruction
	void OnDestroy()
	{
		//Repair links if object in chain is destroyed
		if(PrevWizard!=null)
			PrevWizard.NextWizard = NextWizard;

		if(NextWizard!=null)
			NextWizard.PrevWizard = PrevWizard;
	}
	//----------------------------------------------------
	//Get this class as enumerator
	public IEnumerator GetEnumerator()
	{
		return new WizardEnumerator();
	}
	//----------------------------------------------------
}
//-------------------------------------------------------------------