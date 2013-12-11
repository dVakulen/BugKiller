using UnityEngine;
using System.Collections;

public class GameLogicReseter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        WeaponManager.Reset();
		Player.RestorePlayer();
	}
}
