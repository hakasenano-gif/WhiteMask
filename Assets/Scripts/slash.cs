using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class slash : MonoBehaviour
{
    public float clear_time;
    void Start()
    {
        clear_time = 0.10f;
    }


    void FixedUpdate()
    {
        clear_time-=Time.deltaTime;
        if(clear_time<=0) Destroy(gameObject);

    }
        

        public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("enemy")) 
        {
            collision.gameObject.SendMessage("hit_slash");
        }
    }
}
