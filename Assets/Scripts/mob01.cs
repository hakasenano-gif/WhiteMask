using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Mob : Enemy
{
	public GameObject bulletEnemy01;

	public float nextJumpTime;
	private float MoveRange_y = 4.5f; 
	private float jumpRate = 3f;
	[SerializeField]private float jump_force = 10f; 
	[SerializeField]private float speed = 0.03f;
	

	public override void initialize()
	{

		hp = 3;
		firerate = 1f;
		nextfire = 0.5f;
		size = 1.5f;
		Score = 100;
		nextJumpTime = jumpRate;
		rb = GetComponent<Rigidbody2D>();
		
	}
	public override void attack()
	{
		Instantiate (bulletEnemy01, transform.position, Quaternion.identity);
	}
	public override void move(float t)
	{
		/*床すり抜けの防止*/
		float y = Mathf.Clamp(transform.position.y,-MoveRange_y,MoveRange_y);        
		transform.position=new Vector3(transform.position.x,y,transform.position.z);

		transform.Translate (-speed, 0, 0);

		/*ジャンプ処理*/
		nextJumpTime -= Time.deltaTime;
		if((nextJumpTime <= 0)&&(transform.position.y<= -MoveRange_y)) 
		{
            rb.AddForce(new Vector2(-0.2f,1.0f) * jump_force , ForceMode2D.Impulse);
			nextJumpTime = jumpRate;
        }	
		if(rb.velocity.y < 0 && transform.position.y <= -MoveRange_y)
		{
		rb.velocity = Vector2.zero;	
		}
	}

	public override void OnEnemyDeath()
	{
		int randomValue;
		randomValue = Random.Range(1,101);

		/*
		if(randomValue<=10) アイテム1をドロップ
		*/
	}
}	