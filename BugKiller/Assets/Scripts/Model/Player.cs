using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Model
{
    /// <summary>
    /// This class represents player state. 
    /// It uses Singleton pattern so that you should get 
    /// object by invoking static property "Instance".
    /// </summary>
    public class Player : LivingEntity
    {
        private static Player instance;

        private Player() { }

        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Player();
                }
                return instance;
            }
        }
    }
}
