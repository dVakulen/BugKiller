using UnityEngine;

namespace Assets.Scripts.AI.EnemyStateBehavior
{
    public abstract class EnemyState
    {
        public abstract void Action(EnemyActivity context);
    }
}
