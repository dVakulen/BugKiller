using UnityEngine;
using System.Collections;

public class EnemySounds : MonoBehaviour
{
	public AudioSource audiosource;
	AudioClip sound;
	
	private float walkAudioTimer   ;
	Animator anim;


		void Start ()
		{
		walkAudioTimer =0;
		anim = gameObject.GetComponent<Animator>();
		}
	
		void Update ()
		{
		if(anim.GetBool("Run") )
		{
			if(walkAudioTimer>0.3)
			{
				sound = SoundManager.GetBugFootstepSounds();
				audiosource.PlayOneShot(sound, 1);
				walkAudioTimer = 0;
			}
			walkAudioTimer += Time.deltaTime;
		}

		}
}

