using UnityEngine;
using System.Collections;

public class NewGameBehavior : MonoBehaviour {

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
		Application.LoadLevel(StartLevel);
	}
}
