using System;
using UnityEngine;

public class Character : MonoBehaviour {

	EnumSFM.SFM SFMChoosen;
	int abilityChoosen;

	// Use this for initialization
	void Start () {
		ResetValues();
	}

	public void SetSFMChoosen(EnumSFM.SFM newSFM)
	{
		SFMChoosen = newSFM;
	}

	public EnumSFM.SFM GetSFMChoosen()
	{
		return SFMChoosen;
	}

	public void SetAbilityChoosen(int newAbility)
	{
		abilityChoosen = newAbility;
	}

	public int GetAbilityChoosen()
	{
		return abilityChoosen;
	}

	public void ResetValues()
	{
		abilityChoosen = -1;
		SFMChoosen = EnumSFM.SFM.NONE;
	}
}
