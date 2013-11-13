namespace Assets.Scripts.AI.EnemyStateBehavior
{
    /// <summary>
    /// Abstract class which represents enemy's state.
    /// Use "Action" method to force enemy doing work.
    /// </summary>
    public abstract class EnemyState
    {
        /// <summary>
        /// Checks possible transition in another state and than does work
        /// </summary>
        /// <param name="context">EnemyActivity object which contains all necessary information.</param>
        public void Action(EnemyActivity context)
        {
            CheckTransition(context);
            Work(context);
        }

        /// <summary>
        /// Method which contains appropriate work (action).
        /// </summary>
        /// <param name="context"></param>
        protected abstract void Work(EnemyActivity context);

        /// <summary>
        /// Method which contains transitions checks
        /// </summary>
        /// <param name="context"></param>
        protected abstract void CheckTransition(EnemyActivity context);
    }
}
