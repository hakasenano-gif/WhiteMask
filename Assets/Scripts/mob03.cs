using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Mob3 : Enemy
{
	public float speed = 0.1f;
    public GameObject bulletEnemy01;
	public override void initialize()
	{

		hp = 4;
		firerate=2f;
		size = 0.3f;
		
	}
	public override void attack()
	{
        Instantiate (bulletEnemy01, transform.position, Quaternion.identity);
        Instantiate (bulletEnemy01, transform.position, Quaternion.Euler(0f, 0f, 30f));
        Instantiate (bulletEnemy01, transform.position, Quaternion.Euler(0f, 0f, -30f));
	}
	public override void move()
	{
        if(time<=1) transform.Translate(-0.1f,0,0);
        else transform.Translate (-0.02f, 0, 0);
        
	
	}
}	