using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour
{
	public bool playerInSight;							
	
	
	private SphereCollider col;							
 private GameObject player;							
	
	
	void Awake ()
	{
		// Setting up the references.
		col = GetComponent<SphereCollider>();
	     player = GameObject.Find("Character");
	
	     playerInSight = false;
		}
	
	
	void Update ()
	{
		}
	

	void OnTriggerStay (Collider other)
    {
		// If the player has entered the trigger sphere...
        if(other.gameObject == player)
        {
			playerInSight = true;
			// By default the player is not in sight.
			//WplayerInSight = false;
			
			// Create a vector from the enemy to the player and store the angle between it and forward.
        /*    Vector3 direction = other.transform.position- transform.position;
			//float angle = Vector3.Angle(direction, transform.forward);
            playerInSight = true;
					
			// If the angle between forward and where the player is, is less than half the angle of view...
			//if(angle < fieldOfViewAngle * 0.5f)
			{
				RaycastHit hit;
				
				// ... and if a raycast towards the player hits something...
				if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
				{
					// ... and if the raycast hits the player...
					if(hit.collider.gameObject == player)
					{
						// ... the player is in sight.
						playerInSight = true;
						
						// Set the last global sighting is the players current position.
						//lastPlayerSighting.position = player.transform.position;
					}
				}
			}
			
			// Store the name hashes of the current states.
			//int playerLayerZeroStateHash = playerAnim.GetCurrentAnimatorStateInfo(0).nameHash;
			//int playerLayerOneStateHash = playerAnim.GetCurrentAnimatorStateInfo(1).nameHash;
			
			// If the player is running or is attracting attention...
		//	if(playerLayerZeroStateHash == hash.locomotionState || playerLayerOneStateHash == hash.shoutState)
			{
				// ... and if the player is within hearing range...
			//	if(CalculatePathLength(player.transform.position) <= col.radius)
					// ... set the last personal sighting of the player to the player's current position.
				//	personalLastSighting = player.transform.position;
			}*/
        }
    }
	
	
	void OnTriggerExit (Collider other)
	{
		// If the player leaves the trigger zone...
		if(other.gameObject == player)
			// ... the player is not in sight.
			playerInSight = false;
	}
	
	
	
}
