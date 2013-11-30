using UnityEngine;
using System.Collections;

public class MenuObject : MonoBehaviour {
	AudioSource audiosource;
	public bool isQuit = false;
	public AudioClip   sound;
	void Start()
	{
		audiosource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
	}
	void OnMouseEnter() 
	{
		audiosource.PlayOneShot(sound,1);
		renderer.material.color = Color.red;
	}

	void OnMouseExit() 
	{
		renderer.material.color = Color.white;
	}
	
	void OnMouseDown() 
	{
		if(isQuit)
		{
			Application.Quit();	
		}
		else
		{
			Application.LoadLevel(1);	
		}
	}

}
