using UnityEngine;
using System.Collections;
public class Flashlight : MonoBehaviour {
	GameObject light;
	
	void Start () {
	 light =GameObject.Find("flashlight");
	
	}
	
void TurnlightOn(){
light.light.enabled = false;

}

void TurnlightOff(){
light.light.enabled = true;

}
void Update () {
	if (Input.GetKeyDown(KeyCode.F)){ 
	if (light.light.enabled == true ){
		TurnlightOn();
		} else {
		TurnlightOff();
      }
   }
	}
}
