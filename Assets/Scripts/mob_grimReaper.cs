using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class mob_grimReaper : Enemy
{
	public GameObject bullet_grimReaper;
	[SerializeField]private float speed = 0.03f;


	public GameObject target;
	
	public override void initialize()
	{
		target = GameObject.Find("Player");
		hp = 15;
		firerate = 5f;
		nextfire = 1.5f;
		size = 1.5f;
		Score = 1500;
		
	}
	public override void attack()
	{
		if(target!=null)
		transform.position = new Vector2 (target.transform.position.x + 3f,target.transform.position.y);

	}
	public override void move()
	{
	}


}	