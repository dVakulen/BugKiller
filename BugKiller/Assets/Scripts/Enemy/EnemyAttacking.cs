using UnityEngine;
using System.Collections;

public class EnemyAttacking : MonoBehaviour
{
	public float Damage = 25f;					
	public float flashIntensity = 3f;					
	public float fadeSpeed = 10f;						
    public float attackspeed = 1f;
    public float attackRange = 3f;	
	private SphereCollider col;							
	private Transform player;						
	private PlayerHealth playerHealth;			
	private bool attacking;								
	private float scaledDamage;						
    private float attack;

    Enemy enemy;
    Player play;
	void Awake ()
	{
		// Setting up the references.
		//anim = GetComponent<Animator>();
       
	   col = GetComponent<SphereCollider>(); 
        player = GameObject.Find("Character").transform;
		playerHealth = player.gameObject.GetComponent<PlayerHealth>();
        attack = 25;
       
        play = Player.Instance;

	}
	
	
	void Update ()
	{
		// Cache the current value of the shot curve.
		 attack -= attackspeed;
	//	Debug.LogWarning("ddd");
         Vector3 sightingDeltaPos = player.transform.position - transform.position;
            if(sightingDeltaPos.x<attackRange)
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
	
	
	void Attack ()
	{
		// The enemy is shooting.
		attacking = true;
		
		// The fractional distance from the player, 1 is next to the player, 0 is the player is at the extent of the sphere collider.
		//float fractionalDistance = (col.radius - Vector3.Distance(transform.position, player.position)) / col.radius;
	
		// The damage is the scaled damage, scaled by the fractional distance, plus the minimum damage.
	
		// The player takes damage.
        play.Hit(Damage);

      playerHealth.TakeDamage(Damage);
		
	}
	
	

}
