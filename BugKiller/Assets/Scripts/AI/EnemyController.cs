using Assets.Scripts.AI.EnemyStateBehavior;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform FirstPoint;
    public Transform SecondPoint;
    public float WaypointRadius = 2f;
    public float Damping = 0.1f;
    public float Speed = 2.0f;
    public float AttentionDistance = 5;
	public bool IsBoss = false;
	public GameObject fireball;
	
	internal Vector3 pos;
	internal Quaternion rot;

    private Vector3 currentHeading;
    private int targetwaypoint;
    private Transform xform;
    private bool useRigidbody;
    private Rigidbody rigidmember;
    private Enemy model;
    private Animator anim;
    private EnemyActivity enemyActivity;
	private GameObject lvlexit;
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

    protected void Start()
    {
        if (FirstPoint == null || SecondPoint == null)
        {
            Debug.Log("You have to add two points (two transform object)");
        }

        enemyActivity = new EnemyActivity(this, new EnemyPatrol(this));
		lvlexit = GameObject.Find("ExitFromLevel");
        anim = gameObject.GetComponent<Animator>();
		if(IsBoss)
		{
			pos=  GameObject.Find("Fireball").transform.position;
			rot = GameObject.Find("Fireball").transform.rotation;
			GameObject.Find("Fireball").SetActive(false);
			model.ReceiveHPBonus(500);

		}
    }

    protected void Update()
    {
        if (model.IsAlive)
        {
            enemyActivity.Action();
        }
    }

    void model_OnDying(object obj)
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<SphereCollider>().enabled = false;
        anim.SetBool("Death", true);
		lvlexit.GetComponent<LevelCompleter>().KillEnemy();
        Destroy(this.gameObject, 4);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            model.Damage(5);
        }
    }
}