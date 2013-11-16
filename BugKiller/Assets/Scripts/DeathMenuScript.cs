using UnityEngine;
using System.Collections;

public class DeathMenuScript : MonoBehaviour {

	public GUISkin skin;
	public GameObject buttonTexture;
	public string levelName = "FirstIterationDemo";

	void OnGUI()
	{
		ShowDeathMenu();
	}

	void ShowDeathMenu()
	{
		GUILayout.BeginArea(new Rect((Screen.width*0.5f-50),(Screen.height*0.5f-50),100,100));
		if(GUILayout.Button("Restart"))
		{
			//load needed level
			Application.LoadLevel(levelName);
		}
		if(GUILayout.Button("Exit"))
		{
			//Exit game
			Application.Quit();
		}
		GUILayout.EndArea();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
