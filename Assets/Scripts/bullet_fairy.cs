using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(CircleCollider2D))]

public class bullet_fairy : bulletEnemyParent
{

    public override void initialize()
    {
        radius = 0.3f;
        speed = -0.05f;
        StartCoroutine("facePlayer");

    }
    
    public override void move()
    {
       transform.Translate (speed,0,0);
    }

    IEnumerator facePlayer()
    {

        yield return new WaitForSeconds(0.3f);
        if (target != null)
        {
            Vector2 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            speed = 0.15f;
        }
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