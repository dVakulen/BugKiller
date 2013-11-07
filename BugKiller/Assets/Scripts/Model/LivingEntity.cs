using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    /// <summary>
    /// Base class for all entities, which have live and can be killed
    /// </summary>
    public abstract class LivingEntity 
    {
        /// <summary>
        /// This event is invoked if entiry die.
        /// </summary>
        public event Action<object> OnDying;

        float health;
        float defenceModifier;

        public LivingEntity(float health = 100, float defModifier = 1)
        {
            defenceModifier = defModifier;
            this.health = health;
        }

        public float Health 
        { 
            get 
            { 
                return health; 
            } 
        }

        public float DefenceModifier 
        {
            get 
            {
                return defenceModifier; 
            } 
        }

        public bool IsAlive 
        { 
            get 
            { 
                return health > 0; 
            } 
        }
                
               
        /// <summary>
        /// Deals damage to this entity.
        /// </summary>
        /// <param name="damage">Basic damage</param>
        /// <returns>Real damage which was applied to this object (damage * this.defence modifier)</returns>
        public float Hit(float damage) 
        {
            if (IsAlive)
            {
                float appliedDamage = damage * defenceModifier;
                health -= appliedDamage;
                if (health <= 0)
                {
                    if (OnDying != null)
                    {
                        OnDying(this);    
                    }
                }
                return appliedDamage;
            }
            else
            {
                return 0;
            }
        }
    }

