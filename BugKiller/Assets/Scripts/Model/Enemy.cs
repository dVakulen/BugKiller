
/// <summary>
/// This class represent enemy with 50hp and 0.5 deffence modifier.
/// </summary>
public class Enemy : LivingEntity
{
    public Enemy()
        : base(50f, 1.5f)
    {

    }
	public void ReceiveHPBonus(int hp)
	{
		health = health + hp;

	}
}

