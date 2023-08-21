using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(CircleCollider2D))]

public class bullet_slime : bulletEnemyParent
{
    public override void initialize()
    {
        radius = 0.8f;
        speed = 0.07f;
    }

    public override void move()
    {
        transform.Translate (-speed, 0, 0);

    }

}