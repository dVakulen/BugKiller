using UnityEngine;

public class SoundManager : MonoBehaviour
{
		public AudioClip[] bugFootstepSounds;
		public  AudioClip[] playerScreams;
		public AudioClip[] playerFootstepSounds  ;
		public AudioClip[] playerHitted  ;
		public AudioClip[] bugDeath  ;
		public AudioClip[] bugTakeHit  ;
		public AudioClip[] playerJump ;
	public AudioClip[] girlJump ;

		public static AudioClip[] playerHitted1  ;
		public static AudioClip[] playerFootstepSounds1;
		public static AudioClip[] playerScreams1;
		public static AudioClip[] bugFootstepSounds1;
		public static AudioClip[] bugDeath1  ;
		public static AudioClip[] bugTakeHit1  ;
		public static AudioClip[] playerJump1 ;
	public static AudioClip[] girlJump1 ;
		static bool inst = false;
		public enum Soundtype
		{
				Player,
				Bug,
				Shot
		}


		void Awake ()
		{		
				if (!inst) {
						inst = true;
						playerHitted1 = playerHitted;
						playerScreams1 = playerScreams;
						bugFootstepSounds1 = bugFootstepSounds;
						playerFootstepSounds1 = playerFootstepSounds;
						bugDeath1 = bugDeath;
						bugTakeHit1 = bugTakeHit;
						playerJump1 = playerJump;
			girlJump1= girlJump;
				}


		}

		public 	 static AudioClip GetPlayerFootstepSound ()
		{
				return GetRandomSoundFromArray (playerFootstepSounds1);
		}
	public 	 static AudioClip GetGirlJump ()
	{
		return GetRandomSoundFromArray (girlJump1);
	}
		public 	 static AudioClip GetBugDeath ()
		{
				return GetRandomSoundFromArray (bugDeath1);
		}

		public 	 static AudioClip GetPlayerJump ()
		{
				return GetRandomSoundFromArray (playerJump1);
		}

		public 	 static AudioClip GetBugHitted ()
		{
				return GetRandomSoundFromArray (bugTakeHit1);
		}

		public 	 static AudioClip GetPlayerHitted ()
		{
				return GetRandomSoundFromArray (playerHitted1);
		}

		public 	 static AudioClip GetBugFootstepSounds ()
		{
				return GetRandomSoundFromArray (bugFootstepSounds1);
		}

		public 	 static AudioClip GetPlayerScreams ()
		{
				return GetRandomSoundFromArray (playerScreams1);
		}

		static     AudioClip GetRandomSoundFromArray (AudioClip[] audioClipArray)
		{
				if (audioClipArray.Length > 0) {
		
						return  audioClipArray [Random.Range (0, audioClipArray.Length)];
				}
				return null;
		}

}