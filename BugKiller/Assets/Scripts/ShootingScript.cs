using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {
	
	public float range = 100f;
	
	public float coolDown = 1f;
	float coolDownRemaining = 0;
	
	public float damage = 50f;

	public GameObject BulletObject;	
	
	public Vector3 AdditionalVector;
	public Quaternion AdditionalRotation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		coolDownRemaining -=Time.deltaTime;
		
		if(Input.GetMouseButton(0) && coolDownRemaining<=0)
		{
			Debug.Log("Shoot!");
			Instantiate(BulletObject, this.transform.position+AdditionalVector, this.transform.rotation*AdditionalRotation);
			coolDownRemaining = coolDown;	
		}
	}
}
