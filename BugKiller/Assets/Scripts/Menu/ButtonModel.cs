using UnityEngine;
using System.Collections;
using System;

public class ButtonModel : MonoBehaviour {

	// Use this for initialization
	Color start;
	public Color hover;
	AudioSource audiosource;
	public AudioClip   sound;

	void Start () {
		start = transform.GetComponent<TextMesh>().color;
		hover = Color.red;
		audiosource = GameObject.Find("Main Camera").GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseEnter()
	{
	//	audiosource.PlayOneShot(sound,1);
      	transform.GetComponent<TextMesh>().color = hover;
	}

	void OnMouseExit() 
	{
		transform.GetComponent<TextMesh>().color = start;
	}

	void OnDisable()
	{
		transform.GetComponent<TextMesh>().color = start;
	}
}
