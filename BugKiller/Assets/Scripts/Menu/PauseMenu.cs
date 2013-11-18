using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GUISkin skin;
	public bool paused = false;

	void Update()
	{
		if(paused)
		{
			Time.timeScale = 0;
			Screen.showCursor = true;
			Screen.lockCursor = false;
		}
		else
		{
			Time.timeScale = 1;
			Screen.showCursor = false;
			Screen.lockCursor = true;
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			paused = !paused;
		}

	}

	void OnGUI()
	{
		if(paused)
		Pause();
	}

	void Pause()
	{
		GUILayout.BeginArea(new Rect((Screen.width * 0.5f) - 50, (Screen.height * 0.5f) - 100, 100, 200));
		
		if(GUILayout.Button("Resume"))
		{
			paused = !paused;
		}
		
		if(GUILayout.Button("Main Menu"))
		{
		Application.LoadLevel(0);
		}

		GUILayout.EndArea();

	}
}