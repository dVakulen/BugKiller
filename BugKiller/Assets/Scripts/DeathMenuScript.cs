using UnityEngine;
using System.Collections;

public class DeathMenuScript : MonoBehaviour {

	Player player = Player.Instance;
	public GUISkin skin;
	bool paused = false;
	public GameObject buttonTexture;

	void OnGUI()
	{
		if(!player.IsAlive)
		{
			Debug.Log("Dead + Gui");
			Pause();
			ShowDeathMenu();
		}
	}

	void Pause()
	{
		paused=true;
	}

	void ShowDeathMenu()
	{
		GUILayout.BeginArea(new Rect((Screen.width*0.5f-50),(Screen.height*0.5f-50),100,100));
		if(GUILayout.Button("Restart"))
		{
			Application.LoadLevel(Application.loadedLevelName);
			//to do Load Player normal state
			paused = false;
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
		if(paused)
		{
			Debug.Log("Set time to 0");
			Time.timeScale=0;
		}
		else
		{
			Time.timeScale=1;
		}
	}
}
