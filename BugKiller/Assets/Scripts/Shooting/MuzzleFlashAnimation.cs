using UnityEngine;
using System.Collections;

public class MuzzleFlashAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = Vector3.one * Random.Range(0.5f,1);
	}
}
