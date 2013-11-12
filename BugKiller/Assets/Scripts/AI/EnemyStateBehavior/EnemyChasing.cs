
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.AI.EnemyStateBehavior
{
   public class EnemyChasing : EnemyState
    {
        float range;
        Vector3 start;
        Transform secondPoint;
        Transform Target;
		Transform currentGoal;
        Vector3 currentHeading;
		float timecurve;
		float multiplier = 1.35f;
        	private Transform player;
        public EnemyChasing(float Range,Vector3 Start,Transform Player)          
        {
           this.range = Range;
			start=Start;
			player= Player;
			timecurve = 150;
	     }
		
	
	
        public override void Action(EnemyActivity context) 
        {
//timecurve--;
            //updating direction
			if(Vector3.Distance(player.transform.position ,context.ThisEnemy.position)>4) // hardcoded twice. Why?
            {
               context.ChangeState(context.Getpatrol());
				return;
            }
			if(Vector3.Distance(player.transform.position ,context.ThisEnemy.position)<2) 
            {
               context.ChangeState(context.Getattacking());
				return;
            }
            UpdateDirection(context);

		//	currentGoal.position = start;
            //perform action
            context.Rigidbody.velocity = currentHeading.normalized * context.Speed* multiplier;
            context.ThisEnemy.LookAt(context.ThisEnemy.position + currentHeading);

         /*  if (Vector3.Distance(context.ThisEnemy.position, start.position) >= range)
            {
				currentGoal.position = start;
				timecurve = 150;
              
            }
			else if( timecurve <0)
			{
				currentGoal = player.transform;
					timecurve = 150;
				
			}*/
        }

        void UpdateDirection(EnemyActivity context)
        {
			currentGoal = player;
            currentHeading = currentGoal.position;
        }
    }
}

