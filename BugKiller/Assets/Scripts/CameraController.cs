using UnityEngine;

using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject player1;
    Vector3 offset;
	
	private Transform player;			
	private Vector3 relCameraPos;		
	private float relCameraPosMag;		
	private Vector3 newPos;			
	public float speed = 1.5f;	
    // Use this for initialization
    void Start()
    {
			//player = player1.transform;
		player = GameObject.FindGameObjectWithTag("Player").transform;
		relCameraPos = transform.position - player.position;
		relCameraPosMag = relCameraPos.magnitude - 0.5f;
       
	//	offset = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		Vector3 standardPos = player.position + relCameraPos;
		newPos = standardPos;
		transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);
		SmoothLookAt();
    }
	void SmoothLookAt ()
	{
	    Vector3 relPlayerPosition = player.position - transform.position;
		Quaternion lookAtRotation = Quaternion.LookRotation(relPlayerPosition, Vector3.up);
		transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, speed * Time.deltaTime);
	}
	
}
