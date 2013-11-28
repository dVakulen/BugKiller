using UnityEngine;
using System.Collections;

public class PlayerSound : MonoBehaviour
{
		public AudioSource audiosource;
		public AudioClip sound;
		private float walkAudioTimer = 0.0f;
		Animator anim;
		SoundManager sm;
		private	Player target;
		float hp ;
		CharacterMovingScript cms;
		bool jumped;

		void Start ()
		{
				jumped = false;
				cms = GameObject.Find ("Character").GetComponent<CharacterMovingScript> ();
				target = Player.Instance;
				sm = GameObject.Find ("SoundManager").GetComponent<SoundManager> ();
				anim = gameObject.GetComponent<Animator> ();
				hp = target.Health;
		}
	
		void Update ()
		{
				if (anim.GetBool ("Run")) {
						jumped = false;
						if (walkAudioTimer > 0.3) {
								sound = SoundManager.GetPlayerFootstepSound ();
			
								audiosource.pitch = (1);
								audiosource.PlayOneShot (sound, 1);
								walkAudioTimer = 0;

						}
						walkAudioTimer += Time.deltaTime;
				} /*else if (!cms.grounded && ! jumped) {
						jumped = true;
						PlayPlayerJumpSound ();
				}
				if (cms.grounded)
						jumped = false;
*/
				if (hp > target.Health) {
						sound = SoundManager.GetPlayerHitted ();
						audiosource.PlayOneShot (sound, 1);
						hp = target.Health;

				} else if (hp < target.Health) {
						hp = target.Health;
				}


		}

		public void PlayPlayerJumpSound ()
		{
				sound = SoundManager.GetPlayerJump ();
				audiosource.PlayOneShot (sound, 2);
		}
}

