using Assets.Scripts.AI.EnemyStateBehavior;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform FirstPoint;
    public Transform SecondPoint;

    public float waypointRadius = 2f;
    public float damping = 0.1f;
    public float speed = 2.0f;
    public bool faceHeading = true;
public float chasingRange = 5f;
    private Vector3 currentHeading;
    
    private int targetwaypoint;
    private Transform xform;
    private bool useRigidbody;
    private Rigidbody rigidmember;
    private Enemy model;
    private Animator anim;
    private EnemyActivity enemyActivity;
	  private EnemySight enemySight;
	
    public EnemyController()
    {
        model = new Enemy();
        model.OnDying += model_OnDying;        
    }

    public Enemy GetEnemyModel()
    {
        return model;
    }

    // Use this for initialization
    protected void Start()
    {   
	   if (FirstPoint == null || SecondPoint == null)
        {
            Debug.Log("You have to add two points (two transform object)");
        }

        enemyActivity = new EnemyActivity(
            transform,
            rigidbody,
            speed,
			 new EnemyPatrol(waypointRadius, FirstPoint, SecondPoint),
			 new EnemyPatrol(waypointRadius, FirstPoint, SecondPoint),
			new EnemyChasing(chasingRange,this.transform.position,GameObject.Find("Character").transform),
			new EnemyAttacking(GameObject.Find("Character").transform)
	
            );
		
        anim = gameObject.GetComponent<Animator>();
    }

    void model_OnDying(object obj)
    {
        Destroy(this.gameObject);
        anim.enabled = false;
    }
    
    
    protected void Update()
    {
	
		
        enemyActivity.Action();
    }

 /*   // draws red line from waypoint to waypoint
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (waypoints == null)
            return;
        for (int i = 0; i < waypoints.Length; i++)
        {
            Vector3 pos = waypoints[i].position;
            if (i > 0)
            {
                Vector3 prev = waypoints[i - 1].position;
                Gizmos.DrawLine(prev, pos);
            }
        }
    }
    */
    void OnTriggerEnter(Collider collision) 
    {
        if (collision.gameObject.tag == "bullet")
        {
            model.Hit(5);
        }
    }
	
}