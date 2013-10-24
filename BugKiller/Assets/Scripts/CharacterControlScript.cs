using UnityEngine;

public class CharacterControlScript : MonoBehaviour
{
    public float AnimSpeed = 1.5f;
    public float VelocityModifier = 1;
    public float JumpHeight = 5;

    Animator anim;

    /// <summary>
    /// true if charachter mouse is located in right area of the sreen
    /// </summary>
    bool wasRightDirection;

    CharacterController chController;

    void Start()
    {
        anim = GetComponent<Animator>();
        chController = GetComponent<CharacterController>();
        //wasRightDirection = Input.mousePosition.x > transform.position.x ? true : false;
        //if (!wasRightDirection)
        //{
        //    TurnAround();
        //}
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Shoot", true);
        }
        else
        {
            anim.SetBool("Shoot", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            chController.Move(new Vector3(0, JumpHeight, 0));
        }

        anim.SetFloat("Speed", -h);
        anim.speed = AnimSpeed;
        //Debug.Log(string.Format("Speed = {0}", h));

        chController.Move(new Vector3(-h * VelocityModifier, 0, 0));
    }

    void LateUpdate()
    {
        Vector3 mousePosition = Input.mousePosition;
        if (wasRightDirection && mousePosition.x < Screen.width / 2)
        {
            TurnAround();
            wasRightDirection = false;
            return;
        }
        if (!wasRightDirection && mousePosition.x >= Screen.width / 2)
        {
            TurnAround();
            wasRightDirection = true;
        }
    }

    void TurnAround()
    {
        Debug.Log(string.Format("wasRightDirection {0}", wasRightDirection));

        if (wasRightDirection)
        {
            transform.LookAt(new Vector3(10000, 0, 0));
        }
        else
        {
            transform.LookAt(new Vector3(-10000, 0, 0));
        }
        anim.SetBool("WasRightDirection", wasRightDirection);
    }
}
