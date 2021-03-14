using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//------------------------------------------
[System.Serializable]
public class PlayingCard
{
	public string Name;
	public int Attack;
	public int Defense;
}
//------------------------------------------
public class Using_Stack : MonoBehaviour 
{
	//------------------------------------------
	//Stack of cards
	public Stack<PlayingCard> CardStack = new Stack<PlayingCard>();
	//------------------------------------------
	// Use this for initialization
	void Start () 
	{
		//Create card array
		PlayingCard[] Cards = new PlayingCard[5];

		//Create cards with sample data
		for(int i=0; i<5; i++)
		{
			Cards[i] = new PlayingCard();
			Cards[i].Name = "Card_0" + i.ToString();
			Cards[i].Attack = Cards[i].Defense = i * 3;

			//Push card onto stack
			CardStack.Push(Cards[i]);
		}

		//Now remove cards from stack, popping the top card each time
		while(CardStack.Count > 0)
		{
			PlayingCard PickedCard = CardStack.Pop();

			//Print name of selected card
			Debug.Log (PickedCard.Name);
		}
	}
	//------------------------------------------
}
//------------------------------------------