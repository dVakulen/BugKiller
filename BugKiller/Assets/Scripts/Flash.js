var lightOn : boolean = false;
//var flashlightOn : AudioClip;
//var flashlightOff : AudioClip;

function Update () {
var light : GameObject = GameObject.Find("Spotlight");
if (Input.GetKeyDown(KeyCode.F)){
if (gameObject.light.enabled == true ){
TurnlightOn();
} else {
TurnlightOff();
      }
   }
}

function TurnlightOn(){
//audio.clip = flashlightOn;
//audio.Play();
//yield WaitForSeconds(flashlightOn.length);
gameObject.light.enabled = false;
lightOn = false;
}

function TurnlightOff(){
//audio.clip = flashlightOff;
//audio.Play();
//yield WaitForSeconds(flashlightOff.length);
gameObject.light.enabled = true;
lightOn = true;
}