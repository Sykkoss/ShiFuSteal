using UnityEngine;
using UnityEngine.UI;

public class GameSystemBasic1v1 : MonoBehaviour {

	EnumTurnTypes.TurnTypes currentTurn;

	Character P1Character;
	Character P2Character;

	int P1RoundsWon;
	int P2RoundsWon;

	GameObject ButtonRock;
	GameObject ButtonPaper;
	GameObject ButtonScissors;
	GameObject ButtonAbility1;
	GameObject ButtonAbility2;
	GameObject ButtonAbility3;

	public Text TextP1Score;
	public Text TextP2Score;

	private void Start()
	{
		currentTurn = EnumTurnTypes.TurnTypes.P1SFM;
		P1Character = GameObject.Find("/P1").GetComponent<Character>();
		P2Character = GameObject.Find("/P2").GetComponent<Character>();
		P1RoundsWon = 0;
		P2RoundsWon = 0;
		ButtonRock = GameObject.Find("/UI").transform.GetChild(0).gameObject;
		ButtonPaper = GameObject.Find("/UI").transform.GetChild(1).gameObject;
		ButtonScissors = GameObject.Find("/UI").transform.GetChild(2).gameObject;
		ButtonAbility1 = GameObject.Find("/UI").transform.GetChild(3).gameObject;
		ButtonAbility2 = GameObject.Find("/UI").transform.GetChild(4).gameObject;
		ButtonAbility3 = GameObject.Find("/UI").transform.GetChild(5).gameObject;
	}

	private bool CheckGameObjects()
	{
		if (P1Character == null || P2Character == null ||
			ButtonRock == null || ButtonPaper == null || ButtonScissors == null ||
			ButtonAbility1 == null || ButtonAbility2 == null || ButtonAbility3 == null)
			return false;
		return true;
	}

	private void Update()
	{
		ManageTurns();
		UpdateScores();
	}

	private void ManageTurns()
	{
		int roundWinner = -1;

		if (!CheckGameObjects())
			return;
		switch(currentTurn)
		{
			case EnumTurnTypes.TurnTypes.P1SFM:
				print("P1SFM");
				// Activate SFM Buttons GameObject
				SetActiveSFMButtons(true);
				SetActiveAbilityButtons(false);
				// Check if P1SFMChoice is done
				if (P1Character.GetSFMChoosen() != EnumSFM.SFM.NONE)
				{
					//SetCurrentTurn(EnumTurnTypes.TurnTypes.P1Ability);
					SetCurrentTurn(EnumTurnTypes.TurnTypes.P1Ability);
				}
				break;
			case EnumTurnTypes.TurnTypes.P1Ability:
				print("P1Ability");
				// De activate SFM Buttons GameObject
				SetActiveSFMButtons(false);
				SetActiveAbilityButtons(true);
				// Check if P1 Ability Choice is done
				if (P1Character.GetAbilityChoosen() != -1)
				{
					SetCurrentTurn(EnumTurnTypes.TurnTypes.P2SFM);
				}
				break;
			case EnumTurnTypes.TurnTypes.P2SFM:
				print("P2SFM");
				// Activate SFM Buttons GameObject
				SetActiveSFMButtons(true);
				SetActiveAbilityButtons(false);
				// Check if P2SFMChoice is done
				if (P2Character.GetSFMChoosen() != EnumSFM.SFM.NONE)
				{
					// if true, currentTurn = P2 Ability;
					//SetCurrentTurn(EnumTurnTypes.TurnTypes.P2Ability);
					SetCurrentTurn(EnumTurnTypes.TurnTypes.P2Ability);
				}
				break;
			case EnumTurnTypes.TurnTypes.P2Ability:
				print("P2Ability");
				// De activate SFM Buttons GameObject
				SetActiveSFMButtons(false);
				SetActiveAbilityButtons(true);
				// Check if P2 Ability Choice is done
				if (P2Character.GetAbilityChoosen() != -1)
				{
					SetCurrentTurn(EnumTurnTypes.TurnTypes.EndTurns);
				}
				break;
			case EnumTurnTypes.TurnTypes.EndTurns:
				print("ENd turns");
				SetActiveSFMButtons(false);
				SetActiveAbilityButtons(false);
				// Faire les animations de SFM
				// Faire les effets et les animations des Abilities
				// Dire qui a gagné le SFM
				roundWinner = PickRoundWinner();
				print("Winner of round is: " + roundWinner);
				EndRoundAnimations(roundWinner);
				P1Character.ResetValues();
				P2Character.ResetValues();
				if (P1RoundsWon < 3 && P2RoundsWon < 3)
					currentTurn = EnumTurnTypes.TurnTypes.P1SFM;
				else
					currentTurn = EnumTurnTypes.TurnTypes.EndGame;
				break;
			case EnumTurnTypes.TurnTypes.EndGame:
				print("PARTIE FINIE !");
				if (P1RoundsWon >= 3)
					print("P1 WON");
				else if (P2RoundsWon >= 3)
					print("P2 WOn");
				break;
		}
	}

	int PickRoundWinner()
	{
		EnumSFM.SFM P1SFMChoice = P1Character.GetSFMChoosen();
		EnumSFM.SFM P2SFMChoice = P2Character.GetSFMChoosen();

		if (P1SFMChoice == EnumSFM.SFM.NONE || P2SFMChoice == EnumSFM.SFM.NONE)
			return -1;
		if (P1SFMChoice == EnumSFM.SFM.ROCK)
		{
			if (P2SFMChoice == EnumSFM.SFM.PAPER)
				return 2;
			else if (P2SFMChoice == EnumSFM.SFM.SCISSORS)
				return 1;
			else
				return 0;
		}
		else if (P1SFMChoice == EnumSFM.SFM.PAPER)
		{
			if (P2SFMChoice == EnumSFM.SFM.SCISSORS)
				return 2;
			else if (P2SFMChoice == EnumSFM.SFM.ROCK)
				return 1;
			else
				return 0;
		}
		else if (P1SFMChoice == EnumSFM.SFM.SCISSORS)
		{
			if (P2SFMChoice == EnumSFM.SFM.ROCK)
				return 2;
			else if (P2SFMChoice == EnumSFM.SFM.PAPER)
				return 1;
			else
				return 0;
		}
		return -1;
	}

	void EndRoundAnimations(int roundWinner)
	{
		if (roundWinner == 1)
			P1RoundsWon += 1;
		else if (roundWinner == 2)
			P2RoundsWon += 1;
	}

	void SetActiveSFMButtons(bool shouldActivate)
	{
		ButtonRock.SetActive(shouldActivate);
		ButtonPaper.SetActive(shouldActivate);
		ButtonScissors.SetActive(shouldActivate);
	}

	void SetActiveAbilityButtons(bool shouldActivate)
	{
		ButtonAbility1.SetActive(shouldActivate);
		ButtonAbility2.SetActive(shouldActivate);
		ButtonAbility3.SetActive(shouldActivate);
	}

	public void SetCurrentTurn(EnumTurnTypes.TurnTypes newTurn)
	{
		currentTurn = newTurn;
	}

	public EnumTurnTypes.TurnTypes GetCurrentTurn()
	{
		return currentTurn;
	}

	void UpdateScores()
	{
		TextP1Score.text = P1RoundsWon.ToString();
		TextP2Score.text = P2RoundsWon.ToString();
	}
}
