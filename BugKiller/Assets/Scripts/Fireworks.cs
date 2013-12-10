
using System;
using UnityEngine;

public class Fireworks  : MonoBehaviour
{
		public float delay = 0;
		public GameObject[] Effects;
		GameObject ef;
		float time = 0;
		float t = 10f;

		void Start ()
		{
		time = t;
				time -= delay;
		}

		void FixedUpdate ()
		{
				time += Time.deltaTime;
				if (time > t) {
			time =0;
			Boom();
				}
		}

		void Boom ()
		{


				ef = (GameObject)Instantiate (Effects [UnityEngine.Random.Range (0, Effects.Length)], this.transform.position, Quaternion.identity);
		
				Destroy (ef, 10f); 
		}
				
}


