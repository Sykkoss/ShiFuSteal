using UnityEngine;
using UnityEngine.UI;

public class GameSystemBasic1v1 : MonoBehaviour {

	EnumTurnTypes.TurnTypes currentTurn;

	Character P1Character;
	Character P2Character;

	GameObject ButtonRock;
	GameObject ButtonPaper;
	GameObject ButtonScissors;

	private void Start()
	{
		currentTurn = EnumTurnTypes.TurnTypes.P1SFM;
		P1Character = GameObject.Find("/P1").GetComponent<Character>();
		P2Character = GameObject.Find("/P2").GetComponent<Character>();
		ButtonRock = GameObject.Find("/UI").transform.GetChild(0).gameObject;
		ButtonPaper = GameObject.Find("/UI").transform.GetChild(1).gameObject;
		ButtonScissors = GameObject.Find("/UI").transform.GetChild(2).gameObject;
	}

	private bool CheckGameObjects()
	{
		if (P1Character == null || P2Character == null ||
			ButtonRock == null)// || ButtonPaper == null || ButtonScissors == null)
			return false;
		return true;
	}

	private void Update()
	{
		if (!CheckGameObjects())
		{
			ButtonRock = GameObject.Find("Rock");
			ButtonPaper = GameObject.Find("UI/Paper");
			ButtonScissors = GameObject.Find("UI/Scissors");
			return;
		}
		switch(currentTurn)
		{
			case EnumTurnTypes.TurnTypes.P1SFM:
				print("P1SFM");
				// Afficher Boutons SFM
				ActiveSFMButtons();
				// Check si P1SFMChoice is done
				if (P1Character.GetSFMChoosen() != EnumSFM.SFM.NONE)
				{
					// if true, currentTurn = P1 Ability;
					//SetCurrentTurn(EnumTurnTypes.TurnTypes.P1Ability);
					SetCurrentTurn(EnumTurnTypes.TurnTypes.P2SFM);
				}
				break;
			case EnumTurnTypes.TurnTypes.P2SFM:
				print("P2SFM");
				// Afficher Boutons SFM
				ActiveSFMButtons();
				// Check si P2SFMChoice is done
				if (P2Character.GetSFMChoosen() != EnumSFM.SFM.NONE)
				{
					// if true, currentTurn = P2 Ability;
					//SetCurrentTurn(EnumTurnTypes.TurnTypes.P2Ability);
					SetCurrentTurn(EnumTurnTypes.TurnTypes.P1SFM);
				}
				break;

		}
		// switch currentTurn
		// case for each
	}

	void ActiveSFMButtons()
	{
		ButtonRock.SetActive(true);
		ButtonPaper.SetActive(true);
		ButtonScissors.SetActive(true);
	}

	public void SetCurrentTurn(EnumTurnTypes.TurnTypes newTurn)
	{
		currentTurn = newTurn;
	}

	public EnumTurnTypes.TurnTypes GetCurrentTurn()
	{
		return currentTurn;
	}
}
