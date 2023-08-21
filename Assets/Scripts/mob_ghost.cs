using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class mob_ghost : Enemy
{
	[SerializeField]private float speed = 0.1f;
	public GameObject bullet_ghost;
	private gamemanager Gamemanager;
	
	
	
	
	public override void initialize()
	{
		hp = 2;
		firerate = 5f;
		nextfire = 3f;
		Score = 100;
		size = 2.3f;
		Gamemanager = gamemanager.GetComponent<gamemanager>();

	}
	public override void attack()
	{
		Instantiate (bullet_ghost, transform.position, transform.rotation);
	}
	public override void move()
	{
		transform.Translate(-speed,0,0);
	}

}	