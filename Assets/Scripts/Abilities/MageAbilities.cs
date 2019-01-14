using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageAbilities : MonoBehaviour {

	public delegate void AbilityPointer();

	AbilityPointer[] ability_pointer;

	void Start()
	{
		ability_pointer = new AbilityPointer[2];

		ability_pointer[0] = Ability1;
		ability_pointer[1] = Ability2;
	}

	public void FunctionPointer(int number)
	{
		ability_pointer[number]();
	}

	/* N°1 */
	void Ability1()
	{
		print("Ability 1");
	}

	/* N°2 */
	void Ability2()
	{
		print("Ability 2");
	}
}
