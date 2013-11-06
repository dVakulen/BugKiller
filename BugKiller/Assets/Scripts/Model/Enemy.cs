using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

    /// <summary>
    /// This class represent enemy with 50hp and 0.5 deffence modifier.
    /// </summary>
    public class Enemy : LivingEntity

    {  
        
  
        public Enemy() : base(50f, 1.5f)

        {
            
        }
    }

