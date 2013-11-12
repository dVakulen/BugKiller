using UnityEngine;
using System.Collections;
namespace Assets.Scripts.AI.EnemyStateBehavior
{
public class EnemyAttacking : EnemyState
{
	public float Damage = 25f;								
    public float attackspeed = 1f;
    public float attackRange = 2f;	
	private SphereCollider col;							
	private Transform player;						
	private float attack;

    Enemy enemy;
    Player play;
	void Awake ()
	{
		//anim = GetComponent<Animator>();
       
	    player = GameObject.Find("Character").transform;
	   attack = 25;
       
     

	}
	
		public EnemyAttacking(Transform _Player)
		{
			   player = _Player;
			   play = Player.Instance;
		}
	  public override void Action(EnemyActivity context) 
        {
			 attack -= attackspeed;
	       if(Vector3.Distance(player.position ,context.ThisEnemy.position)>attackRange) 
            {
             context.ChangeState(context.Getchasing());
			return;
            }
		else
			{ 
				if (attack < 0)
                {
                     Attack();
                    attack = 125;
                }
			}
		}
	/*void Update ()
	{
		//if(!col.enabled) col.enabled = true;
		// Cache the current value of the shot curve.
		 attack -= attackspeed;
	     Vector3 sightingDeltaPos = player.transform.position - transform.position;
            if(Vector3.Distance(player.transform.position ,transform.position)>attackRange) //sightingDeltaPos.x<attackRange)
            {
               enemyActivity.ChangeState(EnemyController.Getchasing());
            }
			else
			{ 
				if (attack < 0)
                {
                    // ... shoot
                    Attack();
                    attack = 125;
                }
			}
		// If the shot curve is peaking and the enemy is not currently shooting...
	
		// If the shot curve is no longer peaking...
        //if (shot < 0.5f)
        //{
        //    // ... the enemy is no longer shooting and disable the line renderer.
        //    attacking = false;
        ////    laserShotLine.enabled = false;
        //}
		
        //// Fade the light out.
		//laserShotLight.intensity = Mathf.Lerp(laserShotLight.intensity, 0f, fadeSpeed * Time.deltaTime);
	}
	
	*/
	void Attack ()
	{
		
	
	
		// The player takes damage.
        play.Hit(Damage);

  	}
	}
	
	

}
