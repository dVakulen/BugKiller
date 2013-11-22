using UnityEngine;
using System.Collections;

public class RestartGameBehavior : MonoBehaviour {

	public string StartLevel = "FirstIterationDemo";
	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
		Screen.lockCursor = false;
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
