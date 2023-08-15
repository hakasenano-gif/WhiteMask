using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Mob2 : Enemy
{
	public float speed;
	public override void initialize()
	{

		hp = 30;
		firerate=1000f;
		size = 0.3f;
		speed = 0.05f;
	}
	public override void attack()
	{
	}
	public override void move(float t)
	{
        transform.Translate (-speed, 0, 0);

	
	}
}	