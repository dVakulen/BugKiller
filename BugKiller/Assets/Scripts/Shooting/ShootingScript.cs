using UnityEngine;

public class ShootingScript : MonoBehaviour
{
	public AudioClip firesound;
    public float range = 100f;
    public float coolDown = 1f;
    public float damage = 50f;
    public GameObject BulletObject;
    public GameObject MuzzleFlash;
    public Vector3 AdditionalVector;
    public Quaternion AdditionalRotation;
	bool pause = false;

    float coolDownRemaining = 0;
    Animator anim;

    void Start()
    {
        MuzzleFlash.SetActive(false);
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
		PauseScript.OnPause+=Paused;
    }

	void Paused(object o)
	{
		pause = !pause;
	}

    void Update()
    {
        coolDownRemaining -= Time.deltaTime;
		if(coolDownRemaining*1.1<coolDown) { 
			audio.Stop();
		}
        if (Input.GetMouseButton(0) && coolDownRemaining <= 0 && !pause)
		{
            anim.SetBool("Shoot", true);
			audio.pitch = coolDown;

			audio.PlayOneShot(firesound,1);
            MuzzleFlash.SetActive(true);
			if(this.transform.forward.z>0 && AdditionalVector.x>0 ||this.transform.forward.z<0 && AdditionalVector.x<0)
			{
				AdditionalVector.x*=-1;// z because we have some issues with character Axises
			}
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
