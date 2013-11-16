using UnityEngine;

public class Bonus : MonoBehaviour
{
    public int AdditionalHP = 25;

    Player player;

    void Awake()
    {
        player = Player.Instance;
    }

    /*   void Update()
       {
           this.gameObject.transform.Rotate(0, 2, 0);
       }*/


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            player.ReceiveHPBonus(AdditionalHP);
            Destroy(this.gameObject);
        }
    }
}


