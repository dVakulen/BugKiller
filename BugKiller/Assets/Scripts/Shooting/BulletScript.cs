using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 3f;
    public float MaxDistance = 10000;
    public float LifeTime = 100;

    float spawnTime;

    public GameObject Effect;
    // Use this for initialization
    void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        MaxDistance -= speed;
        if (Time.time > (spawnTime + LifeTime) || MaxDistance <= 0)
        {
            Collisioning();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Collisioning();
    }

    void OnTriggerEnter()
    {
        Collisioning();
    }

    void Collisioning()
    {
        Destroy(this.gameObject);
    }
}
