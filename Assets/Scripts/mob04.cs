using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class mob04 : Enemy
{
	public GameObject bulletEnemy02;
	public override void initialize()
	{

		hp = 3;
		firerate=1f;
		size = 0.3f;
	}
	public override void attack()
	{
		Instantiate (bulletEnemy02, transform.position,Quaternion.Euler(0.0f, 0.0f, -30f));
	}
	public override void move(float t)
	{
		
        if ((transform.position.x > 6f )&&(t<1.0f)) transform.Translate (-0.5f,0,0);
        else if (t>1.0f) transform.Translate (-0.01f,0,0);


	
	}
}	