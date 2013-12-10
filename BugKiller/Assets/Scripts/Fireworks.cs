
using System;
using UnityEngine;

public class Fireworks  : MonoBehaviour
		{
	
	public GameObject Effect;GameObject ef;
	void FixedUpdate ()
	{
	}
	void Boom()
	{
		ef = (GameObject)Instantiate (Effect, this.transform.position, Quaternion.identity);
		
		Destroy (ef, 10f); 
	}
				
		}


