using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Mob : Enemy
{
	public GameObject bulletEnemy01;
	public override void initialize()
	{

		hp = 3;
		firerate=1f;
		size = 10f;
	}
	public override void attack()
	{
		Instantiate (bulletEnemy01, transform.position, Quaternion.identity);
	}
	public override void move(float t)
	{
			
		if     ((0f<=t)&&(t<=1.8f)) transform.Translate (-2f*Time.deltaTime, 0, 0);
		if     ((1.8<t)&&(t<=2.0f)) transform.Translate(-0.5f*Time.deltaTime,0,0);
		else if(5f<=t)     transform.Translate (10f*Time.deltaTime  , 0, 0);				
	
	}
}	