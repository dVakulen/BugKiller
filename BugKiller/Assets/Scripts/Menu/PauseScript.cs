using UnityEngine;
using System.Collections;
using System;

public class PauseScript : MonoBehaviour {

	public GUISkin skin;
	public static bool paused = false;
	public GameObject menu;
	public static event Action<object> OnPause;

	void Start()
	{
		menu.SetActive(false);
	}

	void Update()
	{
		menu.transform.position = this.transform.position + new Vector3(0,0,6);
		if(paused)
		{
			Time.timeScale = 0;
			Screen.showCursor = true;
			Screen.lockCursor = false;
			Debug.Log("Pause!");
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
			Debug.Log(paused);
			menu.SetActive(paused);
			if(OnPause!=null)
				OnPause(this);
		}
	}
	
	public static void CallOnPause()
	{
		if(OnPause!=null)
			OnPause(new object());
		paused=!paused;
		Debug.Log(paused);
	}
}