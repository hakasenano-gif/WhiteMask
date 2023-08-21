using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(CircleCollider2D))]

public class bullet_ghost : bulletEnemyParent
{
    public override void initialize()
    {
        radius = 2.2f;
        speed = 0.15f;
    }

    public override void move()
    {
        transform.Translate (-speed, 0, 0);

    }

}