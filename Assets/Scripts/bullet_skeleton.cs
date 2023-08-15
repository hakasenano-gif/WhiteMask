using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(CircleCollider2D))]

public class bullet_skeleton : bulletEnemyParent
{

    public override void initialize()
    {
        radius = 0.3f;
        speed = -0.075f;
    }
    
    public override void move()
    {
       transform.Translate (speed,0,0);
    }

    public override void slashProcess()
    {
        speed = -speed;
        targetTag = ("enemy");
    }
}

/*
    public float degree;
    public float degree_max = 50f;
    [SerializeField]private float DegChangeSpeed = 60f;
    [SerializeField]private bool Is_rising = false;
    public override void initialize()
    {
        radius = 0.3f;
        speed = -0.1f;
        degree = degree_max; 
    
    }

    public override void move()
    {     
        transform.Translate (speed,0,0);
        if(degree >= degree_max) 
        {
            degree -= DegChangeSpeed*Time.deltaTime;
            Is_rising = true;
        }
        else if(degree <= -degree_max)
        { 
            degree += DegChangeSpeed*Time.deltaTime;
            Is_rising = false;
        }
        else if(Is_rising == true) degree -= DegChangeSpeed*Time.deltaTime;
        else degree += DegChangeSpeed*Time.deltaTime;
        transform.rotation =  Quaternion.Euler (0f,0f,degree);
           
    }

}
*/