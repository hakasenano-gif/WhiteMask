using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class jellyFish : Enemy
{
	private float moveRate;
	private float moveRateMax = 1f;
	private float move_time = 0.7f;
	private float speed = 0.16f;
	private string targetTag = "Player";
	private Vector3 direction;
	public GameObject jellyfish;
	public GameObject target;


	public override void initialize()
	{

		hp = 5;
		firerate=100f;
		size = 0.3f;
		target = GameObject.FindGameObjectWithTag(targetTag);
		
	}
	public override void attack()
	{
	}
	public override void move()
	{
		if(moveRate <= 0) 
		{
			direction = target.transform.position - transform.position;
            direction.z = 0f; 
			moveRate = moveRateMax;
		}
        else if (moveRate >= move_time)
		{
                transform.Translate(direction.normalized * speed);
		}
		moveRate -= Time.deltaTime;

	}
}	