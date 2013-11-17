
/// <summary>
/// This class represents player state. 
/// It uses Singleton pattern so that you should get 
/// object by invoking static property "Instance".
/// </summary>
public class Player : LivingEntity
{
    private static Player instance;

    private Player() { }

    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Player();
            }
            return instance;
        }
    }

    /// <summary>
    /// Creates new player object (can be used for restart level and so on)
    /// </summary>
    public static void RestorePlayer()
    {
        instance = new Player();
    }


    public void ReceiveHPBonus(int hp)
    {
        health = health + hp;
        if (health > 100)
        {
            health = 100;
        }
    }
}

