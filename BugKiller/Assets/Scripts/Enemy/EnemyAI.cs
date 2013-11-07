using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
					// A counter for the way point array.
    public float patrolSpeed = 2f;							
    public float chaseSpeed = 5f;						
    public float Damage = 25f;					
    public float attackspeed = 1f;
    
    public float speed = 0.01f;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;

    private EnemySight enemySight;						
    private Transform player;
    private Transform wp1;
    private Transform wp;// Reference to the player's transform.
    private PlayerHealth playerHealth;					// Reference to the PlayerHealth script.
    //	private DoneLastPlayerSighting lastPlayerSighting;		// Reference to the last global sighting of the player.
    private float chaseTimer;								// A timer for the chaseWaitTime.
    private float patrolTimer;								// A timer for the patrolWaitTime.
    private int wayPointIndex;								// A counter for the way point array.
    private float attack;
    Vector3 targetpos;
    Vector3 startpos;
    Vector3 wprange;
    Enemy enemy;
    void Awake()
    {
        // Setting up the references.
        enemySight = GetComponent<EnemySight>();
        player = GameObject.Find("Character").transform;
        //this.this.GetComponent<Waypoint>();
        wp = GameObject.Find(this.name + "/Waypoint").transform;
        wp1 = GameObject.Find(this.name +  "/Waypoint1").transform;
        Debug.Log(this.name);
        towp = false;
        isdead = false;
        playerHealth = player.GetComponent<PlayerHealth>();
        startpos = rigidbody.position;
       
        isdead = false;
         enemy = new Enemy();
        wprange = wp.transform.position - wp1.transform.position;
        //lastPlayerSighting = GameObject.FindGameObjectWithTag(DoneTags.gameController).GetComponent<DoneLastPlayerSighting>();
    }


    void Update()
    {
        // If the player is in sight and is alive...
        if(!isdead)
        { 
        if (enemySight.playerInSight)
        // ... shoot.Shooting();
        {
            Chasing();
            chasing = false;
        }
        // If the player has been sighted and isn't dead...
        //else if(enemySight.personalLastSighting != lastPlayerSighting.resetPosition && playerHealth.health > 0f)
        // ... chase.


        // Otherwise...
        else
        // ... patrol.
        {
            Patrolling(); chasing = true;
        }
        }
    }


    void Shooting()
    {
        // Stop the enemy where it is.
       // nav.Stop();
    }
    public GameObject projectile;

    void OnTriggerEnter(Collider bullet)
    {
       
       if(bullet.tag== projectile.tag)
        {
            enemy.Hit(15);
           
           if(!enemy.IsAlive)
           { 
            DestroyObject(playername);
       // Debug.Log("A cube has been hit");
      //  DestroyObject(projectile.gameObject);
    //    DestroyObject(this.gameObject);
            Collider S = this.GetComponentInChildren<CapsuleCollider>();
           // S.enabled = false;
              
               
              
            this.rigidbody.MoveRotation(new Quaternion(180, 90, 0, this.rigidbody.rotation.w));
            isdead = true;
            //this.rigidbody.active = false;
               
           }
        }
    }
    bool isdead;
    void Chasing()
    {
       
        // Create a vector from the enemy to the last sighting of the player.
        if(enemySight.playerInSight )
        { 
        Vector3 sightingDeltaPos = player.transform.position - transform.position;

        // If the the last personal sighting of the player is not close...
        //	if(sightingDeltaPos.sqrMagnitude > 4f)
        // ... set the destination for the NavMeshAgent to the last personal sighting of the player.
        targetpos= player.transform.position;
        
        // Set the appropriate speed for the NavMeshAgent.
        if (sightingDeltaPos.x < 1.25&& sightingDeltaPos.x > -1.25)
        {
            this.rigidbody.AddForce(-this.rigidbody.velocity, ForceMode.VelocityChange);
        }else
        if (sightingDeltaPos.x > 0) Move(1);// chaseSpeed;
        else Move(-1);
        }
        else
        {
            Patrolling();
        }
        // If near the last personal sighting...  chaseTimer += Time.deltaTime;chaseWaitTime

    
    }   
    bool initialized;
    GameObject playername;
    void OnGUI()
    {
        if(!isdead)
        { 
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        //Находится ли объект перед камерой
        Vector3 cameraRelative = Camera.main.transform.InverseTransformPoint(transform.position);
        if (cameraRelative.z > 0)
        {
            if (!initialized)
            {
                playername = GameObject.Instantiate(Resources.Load("PlayerText")) as GameObject;
                GUIText name = playername.GetComponent<GUIText>();

                string hp = this.enemy.Health.ToString();
                    name.text = hp;

                initialized = true;
            }
            else
            {
                GUIText name = playername.GetComponent<GUIText>();

                string hp = this.enemy.Health.ToString();
                name.text = hp;

            }

            playername.transform.position = Camera.mainCamera.WorldToViewportPoint(transform.position) + new Vector3(0f, 0.15f, 0f);

        }
        }
    }
    float time1;
    float maxvel = 2f;
    void Move(float sp)
    {
        Vector3 targetVelocity = new Vector3(sp, 0, 0);
      //  targetVelocity *= speed;
       if(this.rigidbody.velocity.x != targetVelocity.x && this.rigidbody.velocity.x< maxvel)
        // Apply a force that attempts to reach our target velocity
      //  Vector3 velocity = rigidbody.velocity;
     //   Vector3 velocityChange = (targetVelocity - velocity);
      // velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
    //    velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
      //  velocityChange.z = 0;
     //   velocityChange.y = 0;
        rigidbody.AddForce(targetVelocity, ForceMode.VelocityChange);
        if( this.rigidbody.velocity.x > maxvel )
        {
            rigidbody.AddForce(-(rigidbody.velocity - new Vector3( maxvel, 0,0)));
        }
    }
    public bool towp;
    int time;
  public  bool chasing;
    void Patrolling()
    {
        Vector3 sightingDeltaPos;
       // Debug.LogError(sightingDeltaPos + "d");
      //  time1 += Time.deltaTime;
       // Debug.LogError(wprange.x / 2 + "a");
       if(towp)
        {
           sightingDeltaPos = this.transform.position - wp.position;
           if (sightingDeltaPos.x > 0)

               Move(1);
           else
               Move(-1);
            //   sightingDeltaPos = this.transform.position - wp.position;
        }
        else
        {
         //    sightingDeltaPos = this.transform.position - wp1.position;
            sightingDeltaPos = this.transform.position - wp1.position;
          if (sightingDeltaPos.x > 0)

             Move(1);
           else
                Move(-1);
        }
        // If the the last personal sighting of the player is not close...
        //	if(sightingDeltaPos.sqrMagnitude > 4f)
        // ... set the destination for the NavMeshAgent to the last personal sighting of the player.
       if (this.transform.position.x > wp.transform.position.x - 0.5 && this.transform.position.x <wp.transform.position.x + 0.5)
       {
           towp = true;
       }
       else if (this.transform.position.x > wp1.transform.position.x - 0.5 && this.transform.position.x < wp1.transform.position.x + 0.5)
       {
           towp = false;
       }
     //  if (sightingDeltaPos.x >= wprange.x / 2 && time1 > 0.5|| sightingDeltaPos.x <= -wprange.x / 2 && time1 > 0.5)
        {
      //      time1 = 0;
      //      towp = !towp;
        }
    
        // Set the appropriate speed for the NavMeshAgent.
    //    if (sightingDeltaPos.x > 0) Move(1);// chaseSpeed;
      //  else Move(-1);
    }
}
