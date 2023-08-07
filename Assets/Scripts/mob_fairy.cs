using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class mob_fairy : Enemy
{
	public GameObject bullet_fairy;
	private float speed;

	public override void initialize()
	{

		hp = 3;
		firerate=2f;
		size = 0.3f;
		speed = 0.05f;
		Score = 80;
	}
	public override void attack()
	{
		Instantiate (bullet_fairy, transform.position, Quaternion.identity);
        Instantiate (bullet_fairy, transform.position, Quaternion.Euler(0f, 0f, 30f));
        Instantiate (bullet_fairy, transform.position, Quaternion.Euler(0f, 0f, -30f));
	}
	public override void move()
	{
		transform.Translate (-speed, 0, 0);

		if(transform.position.x < 0)
		{
			speed = -Mathf.Abs(speed);
		} 
	}
}	