using UnityEngine;
using System.Collections;
using System;

public class PauseScript : MonoBehaviour {

	public GUISkin skin;
	public static bool paused = false;
	public GameObject menu;
	public static event Action<object> OnPause;
	 AudioSource audiosource;
	public AudioClip []  soundOpClose;

	void Start()
	{
		audiosource = GameObject.Find("Character").audio;
		menu.SetActive(false);
	}

	void Update()
	{
		menu.transform.position = this.transform.position + new Vector3(0,0,8.3f);
		menu.SetActive(paused);
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
			Debug.Log(paused);
			if(OnPause!=null)
				OnPause(this);
			if(paused)
			{
				audiosource.PlayOneShot(soundOpClose[0],UnityEngine.Random.Range((float)0.8, (float)1.2));
			}
			else
			{
				audiosource.PlayOneShot(soundOpClose[1], UnityEngine.Random.Range((float)0.8, (float)1.2));
				
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