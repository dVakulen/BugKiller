using UnityEngine;
using System.Collections;

public class PlayerSound : MonoBehaviour
{
		public AudioSource audiosource;
	public AudioClip sound;
		private float walkAudioTimer = 0.0f;
		Animator anim;
	SoundManager sm;
		void Start ()
		{
		sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
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

