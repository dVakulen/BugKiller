using UnityEngine;

namespace Assets.Scripts.AI.EnemyStateBehavior
{
    class EnemyHunting : EnemyState
    {
        Transform player;
        Vector3 currentHeading;

        public EnemyHunting()
        {
            player = GameObject.Find("Character").transform;
        }

        protected override void Work(EnemyActivity context)
        {
            currentHeading = new Vector3(player.position.x - context.ThisEnemy.position.x, 0, 0);
            context.Rigidbody.velocity = currentHeading.normalized * context.Speed;
            context.ThisEnemy.LookAt(context.ThisEnemy.position + currentHeading);
        }

        protected override void CheckTransition(EnemyActivity context)
        {
            //TODO: change " < 3" into not hardcoded style (static class with parameters?)
            if (Vector3.Distance(player.position, context.ThisEnemy.position) < 3)
            {
                //TODO: change state in EnemyActivity
                Debug.Log("Here will be state's change into attack state.");
            }
            if (Vector3.Distance(player.position, context.ThisEnemy.position) > 15)
            {
                //TODO: change state into EnemyPatrol
                Debug.Log("Here will be state's change into attack state.");
                //context.ChangeState(...)
            }
        }
    }
}
