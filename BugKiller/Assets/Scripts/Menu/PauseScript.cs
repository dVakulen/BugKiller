using UnityEngine;
using System.Collections;
using System;

public class PauseScript : MonoBehaviour {

	public GUISkin skin;
	public static bool paused = false;
	public  bool pausedFIX = false;
	public GameObject menu;
	public static event Action<object> OnPause;
	 AudioSource audiosource;
	public AudioClip []  soundOpClose;

	void Start()
	{
		audiosource = gameObject.audio;
		menu.SetActive(false);
	}

	void Update()
	{
		float dx = (float)Math.Tan(this.transform.rotation.x)*4.15f;
		float dy = (float)Math.Tan(this.transform.rotation.y)*4.15f;
		menu.transform.position = this.transform.position + new Vector3(dy,-dx,4.15f);
		menu.transform.rotation = this.transform.rotation;
		menu.SetActive(paused);
		if(paused)
		{
			pausedFIX = true;
			Time.timeScale = 0;
			Screen.showCursor = true;
			Screen.lockCursor = false;

		}
		else
		{
			pausedFIX=false;
			Time.timeScale = 1;
			Screen.showCursor = false;
			Screen.lockCursor = true;
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			paused = !paused;
			Debug.Log(paused);
			if(OnPause!=null)
				OnPause(this);
			if(paused)
			{
				//audiosource.PlayOneShot(soundOpClose[0],1f);
			}
			else
			{
				//audiosource.PlayOneShot(soundOpClose[1], 1);
				
			}
		}
	}
	void LookAtCamera()
	{
		Vector3 relPlayerPosition = GameObject.Find("Main Camera").gameObject.transform.position - transform.position;
		Quaternion lookAtRotation = Quaternion.LookRotation(relPlayerPosition, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation,0);
	}

	public static void Unpause()
	{
		Time.timeScale = 1;
		Screen.showCursor = false;
		Screen.lockCursor = true;
	}

	public static void CallOnPause()
	{
		Debug.Log("Called");
		paused=!paused;
		if(OnPause!=null)
			OnPause(new object());
	}
}