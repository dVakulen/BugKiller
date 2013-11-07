using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;							
	public float resetAfterDeathTime = 5f;				
	public AudioClip deathClip;							
	
	
	private Animator anim;								
		private float timer;							
	private bool playerDead;							
	
	
	void Awake ()
	{
		// Setting up the references.
		//anim = GetComponent<Animator>();
		}
	
	
    void Update ()
	{
		// If health is less than or equal to 0...
		if(health <= 0f)
		{
			// ... and if the player is not yet dead...
			if(!playerDead)
				// ... call the PlayerDying function.
				PlayerDying();
			else
			{
				// Otherwise, if the player is dead, call the PlayerDead and LevelReset functions.
				PlayerDead();
				//LevelReset();
			}
		}
	}
	
	
	void PlayerDying ()
	{
		// The player is now dead.
		playerDead = true;
		
		// Set the animator's dead parameter to true also.
	
		// Play the dying sound effect at the player's location.
	//	AudioSource.PlayClipAtPoint(deathClip, transform.position);
	}
	
	
	void PlayerDead ()
	{
		// If the player is in the dying state then reset the dead parameter.
		
		// Stop the footsteps playing.
		//audio.Stop();
	}
	
	
	void LevelReset ()
	{
		// Increment the timer.
		timer += Time.deltaTime;
		
		//If the timer is greater than or equal to the time before the level resets...
        if (timer >= resetAfterDeathTime)
        {
            
        }
			// ... reset the level.
		
	}
	
	
	public void TakeDamage (float amount)
    {
		// Decrement the player's health by amount.
        health -= amount;
    }
}
