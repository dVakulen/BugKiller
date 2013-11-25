using UnityEngine;

public class SoundManager : MonoBehaviour
{
		public AudioClip[] bugFootstepSounds;
		public  AudioClip[] playerScreams;
		public AudioClip[] playerFootstepSounds  ;
		public AudioClip[] playerHitted  ;
		public static AudioClip[] playerHitted1  ;
		public static AudioClip[] playerFootstepSounds1;
		public static AudioClip[] playerScreams1;
		public static AudioClip[] bugFootstepSounds1;

		public enum Soundtype
		{
				Player,
				Bug,
				Shot
		}


		void Awake ()
		{
				playerHitted1 = playerHitted;
				playerScreams1 = playerScreams;
				bugFootstepSounds1 = bugFootstepSounds;
				playerFootstepSounds1 = playerFootstepSounds;

		}

		public 	 static AudioClip GetPlayerFootstepSound ()
		{
				return GetRandomSoundFromArray (playerFootstepSounds1);
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

				if (audioClipArray.Length > 0)
						return  audioClipArray [Random.Range (0, audioClipArray.Length)];
				return null;
		}

}