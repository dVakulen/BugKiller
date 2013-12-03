using UnityEngine;

public class BulletScript : MonoBehaviour
{
		public float speed = 3f;
		public float MaxDistance = 10000;
		public float LifeTime = 100;
		public bool IsFireball = false;
		public float FireballDamage = 7;
		Player target;
		GameObject ef;
		float spawnTime;
		public GameObject Effect;
		// Use this for initialization
		void Start ()
		{
				spawnTime = Time.time;
				if (IsFireball)
						target = Player.Instance;

		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				if (!IsFireball) {
						transform.Translate (transform.forward * speed * Time.deltaTime, Space.World);
						MaxDistance -= speed;
      
		
				} else {
						transform.Translate (transform.forward * -speed * Time.deltaTime, Space.World);
						MaxDistance -= speed;

				}
				if (Time.time > (spawnTime + LifeTime) || MaxDistance <= 0) {
						Collisioning ();
				}
		}
	
		void OnCollisionEnter (Collision collision)
		{

				Collisioning ();
				if (IsFireball && collision.gameObject.name == "Character")
						target.Damage (FireballDamage);

		}

		void OnTriggerEnter ()
		{
				Collisioning ();
		}

		void Collisioning ()
		{
				if (IsFireball) {
						ef = (GameObject)Instantiate (Effect, this.transform.position, Quaternion.identity);

						Destroy (ef, 10f); 
				}
				Destroy (this.gameObject);
		}
}
