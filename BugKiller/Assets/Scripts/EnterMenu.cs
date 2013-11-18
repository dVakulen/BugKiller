using UnityEngine;
using System.Collections;

public class EnterMenu : MonoBehaviour
{
	void Update()
	{
		if (Input.anyKey) 
		{
			Application.LoadLevel("FirstIterationDemo");
		}
	}
}

