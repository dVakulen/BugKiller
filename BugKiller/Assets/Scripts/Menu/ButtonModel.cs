using UnityEngine;
using System.Collections;
using System;

public class ButtonModel : MonoBehaviour {

	// Use this for initialization
	Color start;
	public Color hover;

	void Start () {
		start = transform.GetComponent<TextMesh>().color;
		hover = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseEnter()
	{
		transform.GetComponent<TextMesh>().color = hover;
	}

	void OnMouseExit() 
	{
		transform.GetComponent<TextMesh>().color = start;
	}
}
