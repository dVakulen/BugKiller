using UnityEngine;
using System.Collections;

public class EnemySounds : MonoBehaviour
{
		public AudioSource audiosource;
		AudioClip sound;
		private float walkAudioTimer   ;
		Animator anim;
		bool inst = false;

		void Start ()
		{
				walkAudioTimer = 0;
				anim = gameObject.GetComponent<Animator> ();
		}
	
		void Update ()
		{
				if (anim.GetBool ("Run")) {
						if (walkAudioTimer > 0.2) {
								sound = SoundManager.GetBugFootstepSounds ();
								audiosource.PlayOneShot (sound, 1);
								walkAudioTimer = 0;
						}
						walkAudioTimer += Time.deltaTime;
				} else if (anim.GetBool ("Death") && !inst) {
						audiosource.Stop ();
						sound = SoundManager.GetBugDeath ();
						audiosource.PlayOneShot (sound, 1);
						inst = true;

				}

		}

		void OnTriggerEnter (Collider collision)
		{
				if (collision.gameObject.tag == "bullet") {
		//	sound = SoundManager.GetBugHitted ();
//audiosource.PlayOneShot (sound, 1);
				}
		}
}

