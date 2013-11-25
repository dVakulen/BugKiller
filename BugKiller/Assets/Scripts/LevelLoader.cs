using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	public string LevelName;

	void OnTriggerStay(Collider other) 
	{
		if (other.gameObject.tag == "Player") 
		{
			if (Input.GetKeyDown(KeyCode.E)) 
			{
				Application.LoadLevel(LevelName);
			}
		}
	}
}
