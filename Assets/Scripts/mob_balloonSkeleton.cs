using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Mob_balloonSkeleton : Enemy
{
	[SerializeField]private bool Is_rising;
	[SerializeField]private float move_y;
	[SerializeField]private float speed = 0.01f;
	private bool Is_balloon_break = false;
	public GameObject bullet_skeleton;
	private gamemanager Gamemanager;
	
	
	
	
	public override void initialize()
	{
		hp = 3;
		firerate = 5f;
		nextfire = 3f;
		size = 2.7f;
		Score = 100;
		Gamemanager = gamemanager.GetComponent<gamemanager>();

	}
	public override void attack()
	{
		Instantiate (bullet_skeleton, transform.position, Quaternion.identity);
	}
	public override void move()
	{
		limitate_move_range();
		if(Is_balloon_break == false)
		{
			if(Is_rising == true) move_y += 0.001f;
			else move_y -=0.001f;
			if(move_y > 0.05f)  Is_rising = false;
			if(move_y < -0.05f) Is_rising = true;
		}

		transform.Translate(-speed,move_y,0);
	}

	public void limitate_move_range()
	{
		float y = Mathf.Clamp(transform.position.y,-Gamemanager.MoveRange_y,Gamemanager.MoveRange_y);        
		transform.position=new Vector3(transform.position.x,y,transform.position.z);
    }

	public void balloonBreak()
	{
		StartCoroutine("falling");
	}

    IEnumerator falling()
	{
		Is_balloon_break = true;
		move_y = 0;

		while(transform.position.y > -Gamemanager.MoveRange_y)
		{	
			if(Gamemanager.Is_paused == false) transform.Translate(0,-0.01f,0);
			yield return null;
		}


	}


}	