using UnityEngine;
using System.Collections;

public class Gender : MonoBehaviour {

	// true - male, false - female
	private static bool gender = true;

	public static void SetMale()
	{
		gender = true;
	}

	public static void SetFemale()
	{
		gender = false;
	}

	public static bool GetGender()
	{
		return gender;
	}
}
