
using System.Timers;
using UnityEngine;
namespace Assets.Scripts.AI.EnemyStateBehavior
{
    class EnemyAttack : EnemyState
    {
        Player target;
        Animator anim;
        Transform player;
		AudioSource audio;
		AudioClip sound;

        //It should be in model class actually.
        Timer attackTimer;
        bool canAttack = true;


        public EnemyAttack(EnemyActivity context)
        {
            target = Player.Instance;
            anim = context.ThisEnemy.GetComponent<Animator>();
            player = GameObject.Find("Character").transform;
            attackTimer = new Timer(1000);
            attackTimer.Elapsed += canAttack_Elapsed;
            attackTimer.Start();

            Debug.Log("Enemy is in EnemyAttack state now");
        }

        void canAttack_Elapsed(object sender, ElapsedEventArgs e)
        {
            canAttack = true;
        }

        protected override void Work(EnemyActivity context)
        {
            anim.SetBool("Run", false);

            if (canAttack)
            {
                Debug.Log("Can attack now");
                anim.SetBool("Attack", true);
				audio = GameObject.Find("Character").audio;
				sound = SoundManager.GetPlayerHitted();
				audio.PlayOneShot(sound, Random.Range((float)0.8, (float)1.2));

                target.Damage(10);
                canAttack = false;
            }
            else
            {
                anim.SetBool("Attack", true);
            }
        }

        protected override void CheckTransition(EnemyActivity context)
        {
            if (Vector3.Distance(player.position, context.ThisEnemy.position) >= 2)
            {
                context.ChangeState(new EnemyHunting(context));
            }
        }
    }
}
