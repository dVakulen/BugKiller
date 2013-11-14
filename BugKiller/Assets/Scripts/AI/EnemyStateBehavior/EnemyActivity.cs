using UnityEngine;

namespace Assets.Scripts.AI.EnemyStateBehavior
{
    public class EnemyActivity
    {
        EnemyState currentState;
        Transform thisEnemy;
        Rigidbody rigidBody;
        float speed;
        float attentionDistance;
        EnemyController enemyController;

        public EnemyActivity(EnemyController controller, EnemyState state)
        {
            enemyController = controller;
            this.thisEnemy = controller.transform;
            this.rigidBody = controller.rigidbody;
            this.speed = controller.Speed;
            this.attentionDistance = controller.AttentionDistance;

            currentState = state;
        }

        public EnemyController EnemyContoller
        {
            get
            {
                return enemyController;
            }
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
