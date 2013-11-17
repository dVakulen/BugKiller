using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Pause script, applied to main camera, or camera on which we need pause.
/// </summary>
public class PauseScript : MonoBehaviour {

	public GUITexture pauseImage;
	bool paused;

	/// <summary>
	/// Occurs when game is paused. All scripts that uses Update or FixedUpdate should use this to stop making changes to scene!
	/// </summary>
	public static event Action<object> OnPause;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
		if(paused)
		{
			Time.timeScale = 0;
		}else
		{
			Time.timeScale = 1;
		}
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			paused=!paused;
			if(OnPause!=null)
			{
				Debug.Log("OnP");
				OnPause(this);//if we'll have some saving game instance better to pass it
			}
		}
	}

	void OnGUI()
	{
		if(paused)
		{
			DrawPause();
		}
	}

	void DrawPause()
	{		
		GUILayout.BeginArea(new Rect((Screen.width*0.5f-50),(Screen.height*0.5f-50),100,400));
		
		if(GUILayout.Button("Continue"))
		{
			//Continue
			paused = false;
			if(OnPause!=null)
			{
				Debug.Log("OnP");
				OnPause(this);//if we'll have some saving game instance better to pass it
			}
		}
		if(GUILayout.Button("Restart"))
		{
			//load current level from the start
			Application.LoadLevel(Application.loadedLevelName);
			Player.RestorePlayer();
		}
		if(GUILayout.Button("Settings"))
		{
			//MainMenu
			Application.LoadLevel("Settings");
		}
		
		if(GUILayout.Button("Exit"))
		{
			//Quit
			Application.Quit();
		}
		GUILayout.EndArea();
	}
}
