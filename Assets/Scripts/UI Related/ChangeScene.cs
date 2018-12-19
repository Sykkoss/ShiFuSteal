using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void ToGameplay()
	{
		SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
	}

	public void ToMainMenu()
	{
		SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
	}

	public void ToSelectNumberRounds()
	{
		SceneManager.LoadScene("Select Number Rounds", LoadSceneMode.Single);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
