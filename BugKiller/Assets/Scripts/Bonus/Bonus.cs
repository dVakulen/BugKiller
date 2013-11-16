using UnityEngine;

public class HPBonus : MonoBehaviour
{
    public int AdditionalHP = 25;

    Player player;

    void Awake()
    {
        player = Player.Instance;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.ReceiveHPBonus(AdditionalHP);
            Destroy(this.gameObject);
        }
    }
}


