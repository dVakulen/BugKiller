using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] waypoints;
    public float waypointRadius = 2f;
    public float damping = 0.1f;
    public bool loop = false;
    public float speed = 2.0f;
    public bool faceHeading = true;

    private Vector3 currentHeading;
    private int targetwaypoint;
    private Transform xform;
    private bool useRigidbody;
    private Rigidbody rigidmember;
    private Enemy model;
    private Animator anim;

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
        xform = transform;
        currentHeading = xform.forward;
        if (waypoints.Length <= 0)
        {
            Debug.Log("No waypoints on " + name);
            enabled = false;
        }
        targetwaypoint = 0;
        if (rigidbody != null)
        {
            useRigidbody = true;
            rigidmember = rigidbody;
        }
        else
        {
            useRigidbody = false;
        }

        anim = gameObject.GetComponent<Animator>();
    }

    void model_OnDying(object obj)
    {
        Destroy(this.gameObject, 2);
        anim.enabled = false;
    }


    // calculates a new heading
    protected void FixedUpdate()
    {
        //targetHeading = waypoints[targetwaypoint].position - xform.position;

        //currentHeading = Vector3.Lerp(currentHeading, targetHeading, damping * Time.deltaTime);
        currentHeading = waypoints[targetwaypoint].position;
    }

    // moves us along current heading
    protected void Update()
    {
        if (useRigidbody)
            rigidmember.velocity = currentHeading.normalized * speed;
        else
            xform.position += currentHeading * Time.deltaTime * speed;
        if (faceHeading)
            xform.LookAt(xform.position + currentHeading);

        if (Vector3.Distance(xform.position, waypoints[targetwaypoint].position) <= waypointRadius)
        {
            targetwaypoint++;
            if (targetwaypoint >= waypoints.Length)
            {
                targetwaypoint = 0;
                if (!loop)
                    enabled = false;
            }
        }
    }


    // draws red line from waypoint to waypoint
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

    void OnTriggerEnter(Collider collision) 
    {
        if (collision.gameObject.tag == "bullet")
        {
            model.Hit(5);
        }
    }

}