using UnityEngine;
using System.Collections;

public class SelectFemale : MonoBehaviour {

	public string StartLevel = "Coridor";
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
		Gender.SetMale();
		Application.LoadLevel(StartLevel);
	}
}
