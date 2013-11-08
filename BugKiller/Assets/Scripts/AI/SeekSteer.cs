// SeekSteer.cs
// Written by Matthew Hughes
// 19 April 2009
// Uploaded to Unify Community Wiki on 19 April 2009
// URL: http://www.unifycommunity.com/wiki/index.php?title=SeekSteer
using UnityEngine;
using System.Collections;

public class SeekSteer : MonoBehaviour
{

    public Transform[] waypoints;
    public float waypointRadius = 2f;
    public float damping = 0.1f;
    public bool loop = false;
    public float speed = 2.0f;
    public bool faceHeading = true;

    private Vector3 currentHeading, targetHeading;
    private int targetwaypoint;
    private Transform xform;
    private bool useRigidbody;
    private Rigidbody rigidmember;


    // Use this for initialization
    protected void Start()
    {
        xform = transform;
        currentHeading = xform.forward;
        if (waypoints.Length <= 0)
        {
            Debug.Log("No waypoints on " + name);
            enabled = false;
        }
        targetwaypoint = 0;
        if (rigidbody != null)
        {
            useRigidbody = true;
            rigidmember = rigidbody;
        }
        else
        {
            useRigidbody = false;
        }
    }


    // calculates a new heading
    protected void FixedUpdate()
    {
        //targetHeading = waypoints[targetwaypoint].position - xform.position;

        //currentHeading = Vector3.Lerp(currentHeading, targetHeading, damping * Time.deltaTime);
        currentHeading = waypoints[targetwaypoint].position;
    }

    // moves us along current heading
    protected void Update()
    {
        if (useRigidbody)
            rigidmember.velocity = currentHeading.normalized * speed;
        else
            xform.position += currentHeading * Time.deltaTime * speed;
        if (faceHeading)
            xform.LookAt(xform.position + currentHeading);

        if (Vector3.Distance(xform.position, waypoints[targetwaypoint].position) <= waypointRadius)
        {
            targetwaypoint++;
            if (targetwaypoint >= waypoints.Length)
            {
                targetwaypoint = 0;
                if (!loop)
                    enabled = false;
            }
        }
    }


    // draws red line from waypoint to waypoint
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (waypoints == null)
            return;
        for (int i = 0; i < waypoints.Length; i++)
        {
            Vector3 pos = waypoints[i].position;
            if (i > 0)
            {
                Vector3 prev = waypoints[i - 1].position;
                Gizmos.DrawLine(prev, pos);
            }
        }
    }

}