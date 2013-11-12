using System;
using UnityEngine;

	public class Bonus :MonoBehaviour
	{
		
		public int additionalhp =25;
		Player play;
		public Bonus ()
		{
		}
		   	void Awake ()
	{
		
       
        play = Player.Instance;

	}
	void Update()
	{
		this.gameObject.transform.Rotate(0,2,0);
	}
	
		
		void OnTriggerEnter(Collider collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
				
            play.Hit(-additionalhp);
			Destroy(this.gameObject);
        }
    }
	}


