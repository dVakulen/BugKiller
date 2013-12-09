using UnityEngine;

namespace Assets.Scripts.AI.EnemyStateBehavior
{
    public class EnemyActivity
    {
		
		public  EnemyController enemyController;

    internal    EnemyState currentState;
        Transform thisEnemy;
        Rigidbody rigidBody;
        float speed;
        float attentionDistance;
	

	   public EnemyActivity(EnemyController controller, EnemyState state)
        {

            enemyController = controller;
            this.thisEnemy = controller.transform;
            this.rigidBody = controller.rigidbody;
            this.speed = controller.Speed;
            this.attentionDistance = controller.AttentionDistance;
			currentState = state;
			if(controller.IsBoss)
				attentionDistance*=50;
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
