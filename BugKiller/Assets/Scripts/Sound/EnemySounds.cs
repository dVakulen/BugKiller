using UnityEngine;
using System.Collections;

public class EnemySounds : MonoBehaviour
{
	public AudioSource audiosource;
	AudioClip sound;
	
	private float walkAudioTimer   = 0.0f;
	Animator anim;


		void Start ()
		{
		anim = gameObject.GetComponent<Animator>();
		}
	
		void Update ()
		{
		if(anim.GetBool("Run") )
		{
			if(walkAudioTimer>0.3)
			{
				sound = SoundManager.GetBugFootstepSounds();
				audiosource.PlayOneShot(sound, Random.Range((float)0.8, (float)1.2));
				walkAudioTimer = 0;
			}
			walkAudioTimer += Time.deltaTime;
		}

		}
}

