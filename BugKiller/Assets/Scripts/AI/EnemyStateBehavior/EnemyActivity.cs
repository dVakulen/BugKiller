using UnityEngine;

namespace Assets.Scripts.AI.EnemyStateBehavior
{
    public class EnemyActivity
    {
        EnemyState currentState;
        Transform thisEnemy;
        Rigidbody rigidBody;
        float speed;
        EnemyPatrol enemypatrol;

        public EnemyActivity(Transform thisEnemy, Rigidbody rigidBody, float speed, EnemyState state)
        {
            this.thisEnemy = thisEnemy;
            this.rigidBody = rigidBody;
            this.speed = speed;

            currentState = state;
        }

        public Transform ThisEnemy
        {
            get
            {
                return thisEnemy;
            }
        }

        public Rigidbody Rigidbody
        {
            get
            {
                return rigidBody;
            }
        }

        public float Speed
        {
            get
            {
                return speed;
            }
        }

        public void Action()
        {
            currentState.Action(this);
        }

        public void ChangeState(EnemyState newState)
        {
            currentState = newState;
        }

        public EnemyState GetState()
        {
            return currentState;
        }
    }
}
