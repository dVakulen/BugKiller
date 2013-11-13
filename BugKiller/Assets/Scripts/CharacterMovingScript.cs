using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class CharacterMovingScript : MonoBehaviour
{

    public float speed = 10.0f;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 2.0f;

    bool grounded = false;
    Animator anim;

    void Awake()
    {
        Debug.Log("CharacterMovingScript");
        rigidbody.freezeRotation = true;
        rigidbody.useGravity = false;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (grounded)
        {
            // Calculate how fast we should be moving
            Vector3 targetVelocity = new Vector3(-Input.GetAxis("Horizontal"), 0, 0);
            //targetVelocity = transform.TransformDirection(targetVelocity);

			if (targetVelocity.x == 0) 
			{
				anim.SetBool("Run", false);
			}
			else
			{
				anim.SetBool("Run", true);
				if (targetVelocity.x > 0) 
				{
					TurnRight();
				}
				else 
				{
					TurnLeft();
				}
			}

			targetVelocity *= speed;
            

            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = rigidbody.velocity;
            Vector3 velocityChange = targetVelocity - velocity;
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            //velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);

            // Jump
            if (canJump && Input.GetKeyDown(KeyCode.W))
            {
                rigidbody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
            }
        }
        else
        {
			//If we're in air we don't run.
			anim.SetBool("Run", false);
        }

        grounded = false;

        // We apply gravity manually for more tuning control
        rigidbody.AddForce(new Vector3(0, -gravity * rigidbody.mass, 0));
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != "Wall")
        {
            grounded = true;    
        }
    }

    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }

	void TurnLeft()
	{
		transform.rotation = Quaternion.LookRotation(new Vector3(-100000, 0, 0));
	}

	void TurnRight()
	{
		transform.rotation = Quaternion.LookRotation(new Vector3(100000, 0, 0));
	}
}