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
						cam.transform.position = cam.transform.position + new Vector3 (5f, 0, 0);
				}




				if (WeaponManager.weaponsCount >= 3) {
			
						Debug.LogError (WeaponManager.weaponsCount.ToString ());
						
						player.position = Point.position;
						boss.SetActive (true);
						GameObject cam = GameObject.FindGameObjectWithTag ("MainCamera");
						cam.transform.position = cam.transform.position + new Vector3 (0, 2.4f, 0); 
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
