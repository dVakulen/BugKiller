using UnityEngine;
using System.Collections;

public class PlayerSound : MonoBehaviour
{
		public AudioSource audiosource;
		AudioClip sound;
		private float walkAudioTimer = 0.0f;
		Animator anim;

		void Start ()
		{
				anim = gameObject.GetComponent<Animator> ();
		}
	
		void Update ()
		{
				if (anim.GetBool ("Run")) {
						if (walkAudioTimer > 0.3) {
								sound = SoundManager.GetPlayerFootstepSound ();
								audiosource.pitch = (1);
								audiosource.PlayOneShot (sound, 1);
								walkAudioTimer = 0;

						}
						walkAudioTimer += Time.deltaTime;
				}
				
		}
}

