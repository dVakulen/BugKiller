using UnityEngine;
using System.Collections;

public class LevelCompleter : MonoBehaviour 
{
	public int EnemiesToKill=4;
	public int lvl = 1;
	/*
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Player"&& EnemiesToKill<=0) 
		{
			WeaponManager.weaponsCount++;
		
			Application.LoadLevel("Coridor");
		}
	}*/
	protected int count=0;
	void OnTriggerStay(Collider other) 
	{
		if (other.gameObject.tag == "Player"&& EnemiesToKill<=0) 
		{
			if (Input.GetKeyDown(KeyCode.E)) 
			{
				WeaponManager.weaponsCount++;
				Player.Instance.ReceiveHPBonus(100);
				if(count == 4)
					WeaponManager.levelcompleted =lvl;
			
				Application.LoadLevel("Coridor");
			}
		}
	}
	public	void KillEnemy()
	{
		count++;
		EnemiesToKill--;
	}
}
