using UnityEngine;
using System.Collections;

public class BossFightController : MonoBehaviour
{
		public Transform Point;
		GameObject boss;
		Transform player;

		void Start ()
		{
				boss = GameObject.Find ("BOSS");
				boss.SetActive (false);

		
				if (WeaponManager.weaponsCount == 2) {
						player = GameObject.FindGameObjectWithTag ("Player").transform;
						player.position = Point.position;
						boss.SetActive (true);
			GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
			cam.transform.position = cam.transform.position + new Vector3(0,2.4f,0); 
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
