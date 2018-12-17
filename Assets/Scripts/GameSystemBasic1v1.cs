using UnityEngine;

public class GameSystemBasic1v1 : MonoBehaviour {

	EnumSFM.SFM P1SFM;
	EnumSFM.SFM P2SFM;
	int P1Won;
	int P2Won;

	// Rounds

	private void Start()
	{
		P1Won = 0;
		P2Won = 0;
	}
}
