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
				if (anim.GetBool ("Run")) {
						if (walkAudioTimer > 0.2) {
								if (Vector3.Distance (this.transform .position, player.position) < 7) {
										audiosource.PlayOneShot (SoundManager.GetBugFootstepSounds (), 1f);
					walkAudioTimer=0;
								}
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

