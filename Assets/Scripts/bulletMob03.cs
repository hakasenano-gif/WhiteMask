using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(CircleCollider2D))]

public class bulletMob03 : bulletEnemyParent
{

    public float rotationIntervalNow;
    private float rotationIntervalMax = 1f;
    public override void initialize()
    {
        radius = 0.3f;
        speed = 0.1f;
        rotationIntervalNow = 0f;
    
    }

    public override void move()
    {     
       if(rotationIntervalNow < 0)
        {
  
            if (target != null)
            {
                Vector2 direction = target.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            rotationIntervalNow = rotationIntervalMax;
        }
        transform.Translate (speed,0,0);
        rotationIntervalNow -= Time.deltaTime;
    }


}



