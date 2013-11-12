using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.AI.EnemyStateBehavior
{
   public class EnemyPatrol : EnemyState
    {
        float waypointRadius;
        Transform firstPoint;
        Transform secondPoint;
        Transform currentGoal;
        Vector3 currentHeading;
          	 Transform player;
      
        public EnemyPatrol(
            float waypointRadius, 
            Transform firstPoint,  
            Transform secondPoint
            )
        {
            this.waypointRadius = waypointRadius;
            this.firstPoint = firstPoint;
            this.secondPoint = secondPoint;
            this.currentGoal = secondPoint;
			
			   player = GameObject.Find("Character").transform;
	
        }

        public override void Action(EnemyActivity context) 
        {
     		
			if (Vector3.Distance(context.ThisEnemy.position, player.position) <= 4 ) //hardcoded ftw
            {
		      context.ChangeState(context.Getchasing());
              return;
            }
			
			
			
            //updating direction
            UpdateDirection(context);

            //perform action
            context.Rigidbody.velocity = currentHeading.normalized * context.Speed;
            context.ThisEnemy.LookAt(context.ThisEnemy.position + currentHeading);

            //check if we have reached destination
            if (Vector3.Distance(context.ThisEnemy.position, currentGoal.position) <= waypointRadius)
            {
                if (currentGoal == firstPoint)
                {
                    currentGoal = secondPoint;
                }
                else
                {
                    currentGoal = firstPoint;
                }
            }
        }

        void UpdateDirection(EnemyActivity context)
        {
            currentHeading = currentGoal.position;
        }
    }
}
