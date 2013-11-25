using UnityEngine;
using System.Collections;

public class LiftTeleporter : MonoBehaviour {

	public Transform Point;

	Transform player;
	bool playerIn;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update () 
	{
		if (playerIn) 
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				player.position = Point.position;
			}
		}	
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Player") 
		{
			playerIn = true;
		}
	}

	void OnTriggerExit(Collider other) 
	{
		if (other.gameObject.tag == "Player") 
		{
			playerIn = false;
		}
	}
}
