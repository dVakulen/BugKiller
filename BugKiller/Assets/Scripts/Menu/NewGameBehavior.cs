using UnityEngine;
using System.Collections;

public class NewGameBehavior : MonoBehaviour {
	public string StartLevel = "GenderSelectScreen";

	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
		Screen.lockCursor = false;
	}

	void OnMouseDown()
	{
		Application.LoadLevel(StartLevel);
	}
}