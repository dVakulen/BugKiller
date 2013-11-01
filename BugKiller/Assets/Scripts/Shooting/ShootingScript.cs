using UnityEngine;

public class ShootingScript : MonoBehaviour
{

    public float range = 100f;
    public float coolDown = 1f;
    public float damage = 50f;
    public GameObject BulletObject;
    public GameObject MuzzleFlash;
    public Vector3 AdditionalVector;
    public Quaternion AdditionalRotation;

    float coolDownRemaining = 0;
    Animator anim;

    void Start()
    {
        MuzzleFlash.SetActive(false);
        anim = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Animator>();
    }

    void Update()
    {
        coolDownRemaining -= Time.deltaTime;

        if (Input.GetMouseButton(0) && coolDownRemaining <= 0)
        {
            Debug.Log("Set Shoot of animator to true");

            anim.SetBool("Shoot", true);
            MuzzleFlash.SetActive(true);
            Instantiate(BulletObject, this.transform.position + AdditionalVector, this.transform.rotation * AdditionalRotation);
            coolDownRemaining = coolDown;
        }
        else
        {
            MuzzleFlash.SetActive(false);
            anim.SetBool("Shoot", false);
        }
    }
}
