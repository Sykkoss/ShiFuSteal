using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetPlayer : MonoBehaviour {

	Button mySelf;
	GameSystemBasic1v1 GameSystem;

	private void Start()
	{
		mySelf = this.GetComponent<Button>();
		if (mySelf == null)
			Destroy(this);
		GameSystem = GameObject.Find("/GameSystemBasic1v1").GetComponent<GameSystemBasic1v1>();
		if (GameSystem == null)
			Destroy(this);
	}

	public void SetPlayerSFM(int newSFM)
	{
		Character P1GameObject = GameObject.Find("/P1").GetComponent<Character>();
		Character P2GameObject = GameObject.Find("/P2").GetComponent<Character>();
		EnumTurnTypes.TurnTypes currentTurn = GameSystem.GetCurrentTurn();

		if (P1GameObject == null || P2GameObject == null)
			return;
		if (currentTurn == EnumTurnTypes.TurnTypes.P1SFM)
		{
			P1GameObject.SetSFMChoosen((EnumSFM.SFM)newSFM);
			print("P1");
		}
		else if (currentTurn == EnumTurnTypes.TurnTypes.P2SFM)
		{
			P2GameObject.SetSFMChoosen((EnumSFM.SFM)newSFM);
			print("P1");
		}
	}

}
