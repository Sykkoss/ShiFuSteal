using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreInfos : MonoBehaviour {

	public Text inputText;

	public void SetNumberRounds(int newNumber)
	{
		NbrLocalRounds.numberRoundsNeeded = newNumber;
	}

	public void SetCustomNumberRounds()
	{
		NbrLocalRounds.numberRoundsNeeded = int.Parse(inputText.text);
	}
}
