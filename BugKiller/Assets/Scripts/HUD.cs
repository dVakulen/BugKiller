using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	// Use this for initialization
    string text;
    string pos;
    GameObject player; private PlayerHealth playerHealth;		
    void OnGUI()
    {

        
        player = GameObject.Find("Character");
      playerHealth = player.gameObject.GetComponent<PlayerHealth>();

      text = "HP  = " + playerHealth.health;
        GUI.Button(new Rect(10, Screen.height - 30, 100, 20), text);
      

    }
}
