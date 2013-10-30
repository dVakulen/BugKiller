using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Represent speed of changes.
    /// </summary>
    public float Speed = 1.5f;

    /// <summary>
    /// Player's transform object.
    /// </summary>
    Transform player;

    /// <summary>
    /// It represents camera's position in relation to player postion.
    /// </summary>
    Vector3 offset;

    /// <summary>
    /// It reperesents new camera's position when player moves.
    /// </summary>
    Vector3 newPos;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.position;
    }

    void FixedUpdate()
    {
        SmoothPositionChanging();
        //SmoothLookAt();
    }

    /// <summary>
    /// This method changes camera's position while player moves.
    /// </summary>
    void SmoothPositionChanging()
    {
        newPos = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, newPos, Speed * Time.deltaTime);
    }

    /// <summary>
    /// This method changes camera's rotation while player moves.
    /// </summary>
    void SmoothLookAt()
    {
        Vector3 relPlayerPosition = player.position - transform.position;
        Quaternion lookAtRotation = Quaternion.LookRotation(relPlayerPosition, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, Speed * Time.deltaTime);
    }
}
