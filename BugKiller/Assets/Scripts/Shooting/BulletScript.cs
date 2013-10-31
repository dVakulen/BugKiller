using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	
	public float speed = 3f;
	
	public float MaxDistance = 10000;
	public float LifeTime = 10;
	float spawnTime;
	
	public GameObject Effect;
	// Use this for initialization
	void Start () {
		spawnTime = Time.deltaTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
		MaxDistance-=speed;
		if(Time.time>spawnTime+LifeTime || MaxDistance<=0)
		{
			Collisioning();
		}
	}
	
	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("CollilionEnter!");
		Collisioning();
	}
	
	void OnTriggerEnter()
	{
		Debug.Log("TriggerCollisionEnter!");
		Collisioning();
	}
	
	void Collisioning()
	{		
		Destroy(this.gameObject);
	}
}
