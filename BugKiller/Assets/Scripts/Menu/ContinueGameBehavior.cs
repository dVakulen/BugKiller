using UnityEngine;
using System.Collections;

public class ContinueGameBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown()
	{	
		PauseScript.Unpause();
		PauseScript.CallOnPause();
	}
}
