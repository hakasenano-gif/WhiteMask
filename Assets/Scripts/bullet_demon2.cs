using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(CircleCollider2D))]

public class bullet_demon2 : bulletEnemyParent
{

    public override void initialize()
    {
        radius = 2.4f;
        speed = 0.15f;
        StartCoroutine("facePlayer");

    }
    
    public override void move()
    {
       transform.Translate (speed,0,0);
    }

    IEnumerator facePlayer()
    {


        if (target != null)
        {
            Vector2 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
    
