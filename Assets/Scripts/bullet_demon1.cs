using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(CircleCollider2D))]

public class bullet_demon1 : bulletEnemyParent
{

    public override void initialize()
    {
        radius = 1f;
        speed = -0.035f;


    }
    
    public override void move()
    {
       transform.Translate (speed,0,0);
    }

}
    
