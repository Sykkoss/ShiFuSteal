using UnityEngine;
using UnityEngine.UI;

public class GameSystemBasic1v1 : MonoBehaviour {

	EnumTurnTypes.TurnTypes currentTurn;

	public GameObject P1GameObject;
	public GameObject P2GameObject;
	Character P1Character;
	Character P2Character;
	Color P1DefaultColor;
	Color P2DefaultColor;
	public Material NonPlayingCharacterMat;

	int P1RoundsWon;
	int P2RoundsWon;

	public GameObject ButtonRock;
	public GameObject ButtonPaper;
	public GameObject ButtonScissors;
	public GameObject ButtonAbility1;
	public GameObject ButtonAbility2;
	public GameObject ButtonAbility3;

	public Text TextP1Score;
	public Text TextP2Score;
	public GameObject GameOverUI;
	public Text TextGameOver;

	private void Start()
	{
		currentTurn = EnumTurnTypes.TurnTypes.P1SFM;
		P1Character = P1GameObject.GetComponent<Character>();
		P2Character = P2GameObject.GetComponent<Character>();
		P1RoundsWon = 0;
		P2RoundsWon = 0;
		P1DefaultColor = P1GameObject.GetComponent<Renderer>().material.color;
		P2DefaultColor = P2GameObject.GetComponent<Renderer>().material.color;
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
				// Activate SFM Buttons GameObject
				SetActiveSFMButtons(true);
				SetActiveAbilityButtons(false);
				P2GameObject.GetComponent<Renderer>().material.color = NonPlayingCharacterMat.color;
				P1GameObject.GetComponent<Renderer>().material.color = P1DefaultColor;
				// Check if P1SFMChoice is done
				if (P1Character.GetSFMChoosen() != EnumSFM.SFM.NONE)
				{
					//SetCurrentTurn(EnumTurnTypes.TurnTypes.P1Ability);
					SetCurrentTurn(EnumTurnTypes.TurnTypes.P1Ability);
				}
				break;
			case EnumTurnTypes.TurnTypes.P1Ability:
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
				P1GameObject.GetComponent<Renderer>().material.color = NonPlayingCharacterMat.color;
				P2GameObject.GetComponent<Renderer>().material.color = P2DefaultColor;
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
				SetActiveSFMButtons(false);
				SetActiveAbilityButtons(false);
				// Faire les animations de SFM
				// Faire les effets et les animations des Abilities
				// Dire qui a gagné le SFM
				roundWinner = PickRoundWinner();
				EndRoundAnimations(roundWinner);
				P1Character.ResetValues();
				P2Character.ResetValues();
				if (P1RoundsWon < 3 && P2RoundsWon < 3)
					currentTurn = EnumTurnTypes.TurnTypes.P1SFM;
				else
					currentTurn = EnumTurnTypes.TurnTypes.EndGame;
				break;
			case EnumTurnTypes.TurnTypes.EndGame:
				DisplayGameOver();
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

	void DisplayGameOver()
	{
		int gameWinner = (P1RoundsWon >= 3) ? (1) : (2);

		GameOverUI.SetActive(true);
		TextGameOver.text = "What a game !\n\nCongratulations to Player " + gameWinner.ToString() + "\n\nRestart the game ?";
	}
}
