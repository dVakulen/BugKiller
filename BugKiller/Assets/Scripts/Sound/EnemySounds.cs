using UnityEngine;
using System.Collections;

public class EnemySounds : MonoBehaviour
{
		public AudioSource audiosource;
		AudioClip sound;
		private float walkAudioTimer   ;
		Animator anim;
		bool inst = false;
		Transform player;

		void Start ()
		{
				player = GameObject.Find ("Character").transform;
				walkAudioTimer = 0;
				anim = gameObject.GetComponent<Animator> ();
		}
	
		void Update ()
		{
		
		if (anim.GetBool ("Death") && !inst) {
						audiosource.Stop ();
						sound = SoundManager.GetBugDeath ();
						audiosource.PlayOneShot (sound, 1);
						inst = true;

				}

		}

		void OnTriggerEnter (Collider collision)
		{
				if (collision.gameObject.tag == "bullet") {
					
				}
		}
}

