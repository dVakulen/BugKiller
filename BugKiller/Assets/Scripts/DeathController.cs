using UnityEngine;

public class DeathController : MonoBehaviour
{

    Player player = Player.Instance;

    void Start()
    {
        player.OnDying += player_OnDying;
    }

    void player_OnDying(object obj)
	{
        Application.LoadLevel("DeathScreen");
    }
}
