using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

	public static int weaponsCount = 1;
	internal static int levelcompleted =0;
	public static void SetWeaponsCount(int count)
	{
		if (weaponsCount <= count) 
		{
			weaponsCount = count;
		}
	}
}
