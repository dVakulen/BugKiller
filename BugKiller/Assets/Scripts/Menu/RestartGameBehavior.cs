using UnityEngine;
using System.Collections;

public class RestartGameBehavior : MonoBehaviour {

	string StartLevel;
	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
		Screen.lockCursor = false;
		StartLevel = DeathController.DeathLevelName;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown()
	{
		Player.RestorePlayer();
		Application.LoadLevel(StartLevel);
	}
}
