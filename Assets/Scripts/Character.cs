using System;
using UnityEngine;

public class Character : MonoBehaviour {

	EnumSFM.SFM SFMChoosen;

	// Use this for initialization
	void Start () {
		SFMChoosen = EnumSFM.SFM.NONE;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetSFMChoosen(EnumSFM.SFM newSFM)
	{
		SFMChoosen = newSFM;
		print("Hello ! My SFM is :" + SFMChoosen);
	}

	public EnumSFM.SFM GetSFMChoosen()
	{
		return SFMChoosen;
	}
}
