using UnityEngine;
using System.Collections;

public class LevelCompleter : MonoBehaviour 
{
	public int EnemiesToKill=4;
	/*
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Player"&& EnemiesToKill<=0) 
		{
			WeaponManager.weaponsCount++;
		
			Application.LoadLevel("Coridor");
		}
	}*/
	void OnTriggerStay(Collider other) 
	{
		if (other.gameObject.tag == "Player"&& EnemiesToKill<=0) 
		{
			if (Input.GetKeyDown(KeyCode.E)) 
			{
				Player.Instance.ReceiveHPBonus(100);

				WeaponManager.weaponsCount++;
				Application.LoadLevel("Coridor");
			}
		}
	}
	public	void KillEnemy()
	{
		EnemiesToKill--;
	}
}
