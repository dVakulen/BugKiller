using UnityEngine;
using System.Collections;

public class LevelCompleter : MonoBehaviour 
{
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Player") 
		{
			Application.LoadLevel("MainScreen");
		}
	}
}
