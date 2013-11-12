using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.AI.EnemyStateBehavior
{
    public class EnemyActivity
    {
        EnemyState currentState;
        Transform thisEnemy;
        Rigidbody rigidBody;
        float speed;
		
 EnemyChasing enemychasing;
 EnemyPatrol enemypatrol;
	 EnemyAttacking enemyattack;

		
		public EnemyActivity(Transform thisEnemy, Rigidbody rigidBody, float speed, EnemyState state, EnemyPatrol patrol,
			EnemyChasing chase,EnemyAttacking attack )
        {
            this.thisEnemy = thisEnemy;
            this.rigidBody = rigidBody;
            this.speed = speed;

            currentState = state;
			
			
				enemypatrol =  patrol;
		enemychasing = chase;
		enemyattack = attack;
	
        }

        public Transform ThisEnemy { get { return thisEnemy; } }
        public Rigidbody Rigidbody { get { return rigidBody; } }
        public float Speed { get { return speed; } }

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
          return  currentState ;
        }
		public  EnemyState Getchasing()
	{
		return enemychasing;
	}
	public  EnemyState Getattacking()
	{
		return enemyattack;
	}
		public  EnemyState Getpatrol()
	{
		return enemypatrol;
	}
    }
}
