using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	
	public float speed = 3f;
	
	public GameObject Effect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
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
		if(Effect!=null)
		{
			Instantiate(Effect,transform.position,Quaternion.identity);	
		}		
		Destroy(this.gameObject);
	}
}
