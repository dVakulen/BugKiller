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

    public EnemyController()
    {
        model = new Enemy();
        model.OnDying += model_OnDying;
    }

    public Enemy GetEnemyModel()
    {
        return model;
    }

    /// <summary>
    ///  Draws red line from waypoint to waypoint.
    /// </summary>
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(FirstPoint.position, SecondPoint.position);
    }

    // Use this for initialization
    protected void Start()
    {
        if (FirstPoint == null || SecondPoint == null)
        {
            Debug.Log("You have to add two points (two transform object)");
        }

        enemyActivity = new EnemyActivity(transform, rigidbody, speed,
            new EnemyPatrol(waypointRadius, FirstPoint, SecondPoint)
            );

        anim = gameObject.GetComponent<Animator>();
    }

    protected void Update()
    {
        enemyActivity.Action();
    }

    void model_OnDying(object obj)
    {
        Destroy(this.gameObject);
        anim.enabled = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            model.Hit(5);
        }
    }
}