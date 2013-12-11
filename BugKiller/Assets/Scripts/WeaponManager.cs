using UnityEngine;
using System.Collections;

public static class WeaponManager
{
    public static int weaponsCount = 1;
    internal static int levelcompleted = 0;
    public static void SetWeaponsCount(int count)
    {
        if (weaponsCount <= count)
        {
            weaponsCount = count;
        }
    }

    public static void Reset()
    {
        weaponsCount = 1;
        levelcompleted = 0;
    }
}
