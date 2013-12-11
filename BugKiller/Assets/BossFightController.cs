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
				player = GameObject.FindGameObjectWithTag ("Player").transform;

				if (WeaponManager.levelcompleted == 1) {
						GameObject cam = GameObject.FindGameObjectWithTag ("MainCamera");
						player.position = GameObject.Find ("LevelLoader1").transform.position;
			cam.transform.position = cam.transform.position + new Vector3 (	player.position.x, 0, 0);
				}




		if (WeaponManager.levelcompleted ==2) { 
			
						Debug.LogError (WeaponManager.weaponsCount.ToString () + "  ");
							player.position = Point.position;
						boss.SetActive (true);
						GameObject cam = GameObject.FindGameObjectWithTag ("MainCamera");
			cam.transform.position =  new Vector3 (player.position.x,cam.transform.position.y + 2.8f,cam.transform.position.z); 
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
