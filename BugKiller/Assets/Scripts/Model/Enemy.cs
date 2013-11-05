using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model
{
    /// <summary>
    /// This class represent enemy with 50hp and 0.5 deffence modifier.
    /// </summary>
    public class Enemy : LivingEntity
    {
        public Enemy() : base(0.5f, 50f)
        {
            
        }
    }
}
