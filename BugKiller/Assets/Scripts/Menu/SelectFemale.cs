using UnityEngine;
using System.Collections;

public class SelectMale : MonoBehaviour {
	
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
		Gender.SetFemale();
		Application.LoadLevel(StartLevel);
	}
}
