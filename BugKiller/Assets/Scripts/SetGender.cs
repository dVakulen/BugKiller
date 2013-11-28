using UnityEngine;
using System.Collections;

public class SetGender : MonoBehaviour {

	public GameObject male;
	public GameObject female;

	// Use this for initialization
	void Start () {
		male.SetActive(false);
		female.SetActive(false);
		if (Gender.GetGender() == true) {
			male.SetActive(true);
		} 
		else
		{
			female.SetActive(true);
		}
	}

	void OnEnable()
	{
		Start();
	}
}