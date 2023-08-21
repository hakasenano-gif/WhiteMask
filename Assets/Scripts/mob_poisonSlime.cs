using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class mob_poisonSlime : Enemy
{
	public GameObject bullet_poisonSlime;

	public float nextJumpTime;
	private float MoveRange_y = 4.5f; 
	private float jumpRate = 1.5f;
	[SerializeField]private float jump_force = 13.5f; 
	[SerializeField]private float speed = 0.02f;
	

	public override void initialize()
	{

		hp = 6;
		firerate = 3f;
		nextfire = 3f;
		size = 1.5f;
		Score = 600;
		nextJumpTime = jumpRate;
		rb = GetComponent<Rigidbody2D>();
		
	}
	public override void attack()
	{

		Instantiate (bullet_poisonSlime, transform.position, Quaternion.Euler(0f, 0f,-135));
		Instantiate (bullet_poisonSlime, transform.position, Quaternion.Euler(0f, 0f,-150));
		Instantiate (bullet_poisonSlime, transform.position, Quaternion.Euler(0f, 0f,-175));				

	}
	public override void move()
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


}	