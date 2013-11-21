using UnityEngine;

public class DeathController : MonoBehaviour
{

    Player player = Player.Instance;
	 AudioSource audiosource;
	AudioClip sound;
    void Start()
    {
		audiosource =GameObject.Find("Character").audio;
        player.OnDying += player_OnDying;
    }

    void player_OnDying(object obj)
	{
		sound = SoundManager.GetPlayerScreams();
		audiosource.PlayOneShot(sound, Random.Range((float)0.8, (float)1.2));
		System.Threading.Thread.Sleep(1500);
        Application.LoadLevel("DeathScreen");
    }
}
