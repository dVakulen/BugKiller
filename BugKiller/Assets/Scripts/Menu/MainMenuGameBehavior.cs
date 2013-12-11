using UnityEngine;
using System.Collections;

public class MainMenuGameBehavior : MonoBehaviour {
	void OnMouseDown()
	{
		PauseScript.Unpause();
		PauseScript.CallOnPause();
		Application.LoadLevel("MainScreen");
	}
}
