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
        float attentionDistance;

        public EnemyActivity(Transform thisEnemy, Rigidbody rigidBody, float speed, float attDist, EnemyState state)
        {
            this.thisEnemy = thisEnemy;
            this.rigidBody = rigidBody;
            this.speed = speed;
            this.attentionDistance = attDist;

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

        public float AttentionDistance
        {
            get
            {
                return attentionDistance;
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
