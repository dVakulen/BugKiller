using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip firesound;
    public float range = 100f;
    public static float damage = 0f;
    public GameObject BulletObject;
    public GameObject MuzzleFlash;
    bool pause = false;

    Quaternion AdditionalRotation;
    Vector3 AdditionalVector;
    float coolDownRemaining = 0;
    float coolDown = 0.5f;
    Animator anim;

    // Location of bullet spawn...
    float X = 1.1f;
    float Y = 1.5f;
    float Z = 0f;

    // Various weapons
    public GameObject revolver;
    public GameObject uzi;

    void Start()
    {
        uncheckWeapons();
        if (WeaponManager.weaponsCount >= 2)
            checkUzi();

        else
            checkRevolver();

        AdditionalVector.Set(X, Y, Z);
        AdditionalRotation.Set(0f, 0f, 1f, 1f);
        MuzzleFlash.SetActive(false);
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        PauseScript.OnPause += Paused;
    }

    void Paused(object o)
    {
        pause = !pause;
        coolDownRemaining = coolDown;
    }

    void Update()
    {
        if (coolDownRemaining * 1.1 < coolDown && !uzi.activeSelf)
        {
            audiosource.Stop();
        }
        coolDownRemaining -= Time.deltaTime;
        swapDirection();
        checkWeapon();

        if (Input.GetMouseButton(0) && coolDownRemaining <= 0 && !pause)
        {
            if (!audiosource.isPlaying)
                audiosource.Play();
            anim.SetBool("Shoot", true);
            MuzzleFlash.SetActive(true);
            Instantiate(BulletObject, this.transform.position + AdditionalVector, this.transform.rotation * AdditionalRotation);
            coolDownRemaining = coolDown;
        }
        else if (!Input.GetMouseButton(0) && coolDownRemaining <= 0 && !pause)
        {
            audiosource.Stop();

        }
        else
        {

            MuzzleFlash.SetActive(false);
            anim.SetBool("Shoot", false);
        }
    }

    void swapDirection()
    {
        if (this.transform.rotation.y < 0)
            AdditionalVector.Set(-X, Y, Z);
        else
            AdditionalVector.Set(X, Y, Z);
    }

    void checkWeapon()
    {
        string input = Input.inputString;
        if (input == "1" || input == "2")
        {
            if (WeaponManager.weaponsCount >= 2)
            {
                uncheckWeapons();
                switch (input)
                {
                    case "1":
                        checkRevolver();
                        break;
                    case "2":
                        checkUzi();
                        break;
                }
            }
        }
    }

    void uncheckWeapons()
    {
        revolver.SetActive(false);
        uzi.SetActive(false);
    }

    void checkRevolver()
    {
        revolver.SetActive(true);
        damage = 5f;
        coolDown = 0.5f;
    }

    void checkUzi()
    {
        uzi.SetActive(true);
        damage = 2f;
        coolDown = 0.2f;
    }
}
