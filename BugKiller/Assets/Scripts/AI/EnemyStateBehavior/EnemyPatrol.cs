using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.AI.EnemyStateBehavior
{
    class EnemyPatrol : EnemyState
    {
        float waypointRadius;
        Transform firstPoint;
        Transform secondPoint;
        Transform currentGoal;
        Vector3 currentHeading;
        
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
        }

        public override void Action(EnemyActivity context) 
        {
            //here should be transition check...

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
