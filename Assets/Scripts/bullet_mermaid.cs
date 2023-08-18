using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(CircleCollider2D))]

public class bullet_mermaid : bulletEnemyParent
{
    public override void initialize()
    {
        radius = 1f;
        speed = 0.1f;
    }

    public override void move()
    {
        transform.Translate (-speed, 0, 0);

    }

}