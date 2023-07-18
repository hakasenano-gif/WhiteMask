using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class bulletPlayer : MonoBehaviour
{
    public float speed = 0.75f;
    public float dis;
    public Vector2 LF_pos;
    public Vector2 CF_pos;
    public Vector2 dir;
    public RaycastHit2D hit;
    private float radius = 0.3f;


    // Start is called before the first frame update
    void Start()
    {
        CircleCollider2D collider = GetComponent<CircleCollider2D> ();
        collider.isTrigger = true;
        collider.radius = radius;
        this.tag = "bullet";
        LF_pos = transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate (speed,0,0);
        out_range_process();
        /*raycastを使った衝突判定開始*/
        CF_pos = transform.position;
        dir = (LF_pos - CF_pos).normalized;
        dis = Vector2.Distance(CF_pos,LF_pos);
    
        if(hit = Physics2D.CircleCast(CF_pos,radius,dir, dis))
        {
            if(hit.collider.gameObject.tag == "enemy")
            {

                Destroy(gameObject);    
                hit.collider.gameObject.SendMessage("hit");
            }
        }
        LF_pos = CF_pos;
        /*raycastを使った衝突判定終了*/
    }


    void out_range_process()
    {		
        if((transform.position.x > 10)||(transform.position.x < -10)||(transform.position.y > 5)||(transform.position.y < -5)) 
        {
        Destroy (gameObject);
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("enemy")) 
        {
            collision.gameObject.SendMessage("hit");
            Destroy (gameObject);
        }
    }
}
