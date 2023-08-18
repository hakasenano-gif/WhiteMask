using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class mob05 : Enemy
{
	public GameObject bulletEnemy03;
	public override void initialize()
	{

		hp = 3;
		firerate=1f;
		size = 0.4f;
	}
	public override void attack()
	{
		Instantiate (bulletEnemy03, transform.position,Quaternion.Euler(0.0f, 0.0f, 0.0f));
	}
	public override void move()
	{
		
        if ((transform.position.x > 6f )&&(time<1.0f)) transform.Translate (-0.5f,0,0);
        else if (time>1.0f) transform.Translate (-0.01f,0,0);


	
	}
}	