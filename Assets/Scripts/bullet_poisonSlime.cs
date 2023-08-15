using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(CircleCollider2D))]

public class bullet_poisonSlime : bulletEnemyParent
{
    public Rigidbody2D rb;
    private float UpForce = 12f;		
    public override void initialize()
    {
        radius = 0.3f;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(-Mathf.Cos(transform.rotation.z),-Mathf.Sin(transform.rotation.z)) * UpForce , ForceMode2D.Impulse);
    }

    public override void move()
    {
        

    }

}