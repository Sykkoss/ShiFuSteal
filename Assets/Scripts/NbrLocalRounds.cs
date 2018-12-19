using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NbrLocalRounds{

	public static int numberRoundsNeeded = 3;

	public static void SetNumberRoundsNeeded(int newNumber)
	{
		numberRoundsNeeded = newNumber;
	}

	public static int GetNumberRoundsNeeded()
	{
		return numberRoundsNeeded;
	}
}
