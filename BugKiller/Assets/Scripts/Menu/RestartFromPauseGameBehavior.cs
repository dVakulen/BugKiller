using UnityEngine;
using System.Collections;

public class RestartFromPauseGameBehavior : MonoBehaviour {
	public string StartLevel = "FirstIterationDemo";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}	

	void OnMouseDown()
	{
		PauseScript.CallOnPause();
		Player.RestorePlayer();
		Application.LoadLevel(Application.loadedLevelName);		
	}
}
