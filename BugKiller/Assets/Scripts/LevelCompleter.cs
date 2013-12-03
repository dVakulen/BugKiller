using UnityEngine;
using System.Collections;

public class LevelCompleter : MonoBehaviour 
{
	public int EnemiesToKill=4;
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Player"&& EnemiesToKill<=0) 
		{
			WeaponManager.SetWeaponsCount(2);
			Application.LoadLevel("Coridor");
		}
	}
	public	void KillEnemy()
	{
		EnemiesToKill--;
	}
}
