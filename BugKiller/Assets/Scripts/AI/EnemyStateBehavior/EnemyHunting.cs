using UnityEngine;

namespace Assets.Scripts.AI.EnemyStateBehavior
{
    class EnemyHunting : EnemyState
    {
        Transform player;
        Vector3 currentHeading;
        Animator anim;

        public EnemyHunting(EnemyActivity context)
        {
            player = GameObject.Find("Character").transform;
            anim = context.ThisEnemy.GetComponent<Animator>();
        }

        protected override void Work(EnemyActivity context)
        {
			if(!context.enemyController.IsBoss)
			{
            anim.SetBool("Run", true);
            anim.SetBool("Attack", false);
            currentHeading = new Vector3(player.position.x - context.ThisEnemy.position.x, 0, 0);
            context.Rigidbody.velocity = currentHeading.normalized * context.Speed;
            context.ThisEnemy.LookAt(context.ThisEnemy.position + currentHeading);
			}
        }

        protected override void CheckTransition(EnemyActivity context)
        {
            //TODO: change " < 3" into not hardcoded style (static class with parameters?)
			if (Vector3.Distance(player.position, context.ThisEnemy.position) < 1.75 && !context.enemyController.IsBoss)
            {
                //TODO: change state in EnemyActivity
                Debug.Log("Here will be state's change into attack state.");
                context.ChangeState(new EnemyAttack(context));
            }
			else if ( context.enemyController.IsBoss)
			{
				if (Vector3.Distance(player.position, context.ThisEnemy.position) < 25)
				{
					Debug.Log("Here will be state's change into attack state.");

						context.ChangeState(new EnemyAttack(context));
				}
			}
			if (Vector3.Distance(player.position, context.ThisEnemy.position ) > 15 && !context.enemyController.IsBoss)
            {
                //TODO: change state into EnemyPatrol
                context.ChangeState(new EnemyPatrol(context.EnemyContoller));
            }
        }
    }
}
