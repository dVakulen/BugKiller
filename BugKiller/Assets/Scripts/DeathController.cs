using UnityEngine;

public class DeathController : MonoBehaviour
{

    Player player = Player.Instance;
	 AudioSource audiosource;
	AudioClip sound;
	public static string DeathLevelName;

    void Start()
    {
		audiosource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        player.OnDying += player_OnDying;
    }

    void player_OnDying(object obj)
	{
		DeathLevelName = Application.loadedLevelName;
		if(!Gender.GetGender())
			sound = SoundManager.GetPlayerScreams();
		else
			sound = SoundManager.GetPlayerFemaleScreams();

		try
		{
		audiosource.PlayOneShot(sound, 1);
		System.Threading.Thread.Sleep(1500);
		Player.RestorePlayer();
        Application.LoadLevel("DeathScreen");
		}
		catch
		{

			Player.RestorePlayer();
			Application.LoadLevel("DeathScreen");

		}
    }
}
