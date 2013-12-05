using System.Timers;
using UnityEngine;

class Fireballs : MonoBehaviour
{
	float X = -1.1f;
	float Y = 1.5f;
	float Z = 0f;

	public void ShootBall (GameObject Fireball, Vector3 pos, Quaternion rot)
	{
		Instantiate (Fireball, pos, rot);
	}
}

namespace Assets.Scripts.AI.EnemyStateBehavior
{
	class EnemyAttack : EnemyState
	{
		Player target;
		Animator anim;
		Transform player;
		AudioSource audio;
		AudioClip sound;
		PauseScript pausescript;
		//It should be in model class actually.
		Timer attackTimer;
		bool canAttack = true;
		bool isboss;
		Fireballs fireballs;
		GameObject fireball;
		float coolDownRemaining = 0;
		float coolDown = 2.9f;
		bool inst = false;

		public EnemyAttack (EnemyActivity context)
		{
			target = Player.Instance;
			anim = context.ThisEnemy.GetComponent<Animator> ();
			player = GameObject.Find ("Character").transform;
			attackTimer = new Timer (1000);
			attackTimer.Elapsed += canAttack_Elapsed;
			attackTimer.Start ();
			pausescript = GameObject.Find ("Main Camera").GetComponent<PauseScript> ();
			isboss = context.enemyController.IsBoss;
			if (isboss) 
			{
				fireballs = new Fireballs ();
				fireball = context.enemyController.fireball;
			}
				Debug.Log ("Enemy is in EnemyAttack state now");
		}

		void canAttack_Elapsed (object sender, ElapsedEventArgs e)
		{
			canAttack = true;
		}

		protected override void Work (EnemyActivity context)
		{
			anim.SetBool ("Run", false);
			if (!isboss) 
			{
				if (canAttack && !pausescript.pausedFIX) 
				{
					Debug.Log ("Can attack now");
					anim.SetBool ("Attack", true);
					audio = GameObject.Find ("Character").audio;
					sound = SoundManager.GetPlayerHitted ();
					audio.PlayOneShot (sound, Random.Range ((float)0.8, (float)1.2));
					target.Damage (10);
					canAttack = false;
				}
				else
				{
					anim.SetBool ("Attack", false);
				}
			}
			else
			{ 
				coolDownRemaining -= Time.deltaTime;
				if (coolDownRemaining <= 0 && !pausescript.pausedFIX) 
				{
					anim.SetBool ("Attack", true);
					coolDownRemaining = coolDown;
					fireballs.ShootBall (fireball, context.enemyController.pos, context.enemyController.rot);
				}
			}
		}

		protected override void CheckTransition (EnemyActivity context)
		{
			if (!isboss) 
			{
				if (Vector3.Distance (player.position, context.ThisEnemy.position) >= 2) 
				{
					context.ChangeState (new EnemyHunting (context));
				}
			}
		}
	}
}