using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class mob_slime : Enemy
{
	public GameObject bullet_slime;

	public float nextJumpTime;
	private float MoveRange_y = 4.5f; 
	private float jumpRate = 3f;
	[SerializeField]private float jump_force = 13.5f; 
	[SerializeField]private float speed = 0.03f;
	

	public override void initialize()
	{

		hp = 3;
		firerate = 1f;
		nextfire = 0.5f;
		size = 1.5f;
		Score = 200;
		nextJumpTime = jumpRate;
		rb = GetComponent<Rigidbody2D>();
		
	}
	public override void attack()
	{
		Instantiate (bullet_slime, transform.position, Quaternion.identity);
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