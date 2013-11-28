using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

	public static int weaponsCount = 1;

	public static void SetWeaponsCount(int count)
	{
		if (weaponsCount <= count) 
		{
			weaponsCount = count;
		}
	}
}
