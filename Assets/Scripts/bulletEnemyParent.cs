using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class bulletEnemyParent : MonoBehaviour
{
    public float speed;
    public Vector2 LF_pos;
    public Vector2 CF_pos;
    public Vector2 dir;
    public float dis;
    public RaycastHit2D hit;
    public float radius;
    public string targetTag = "Player";
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag);
        CircleCollider2D collider = GetComponent<CircleCollider2D> ();
        initialize();
        collider.isTrigger = true;
        this.tag = "bullet";
        LF_pos = transform.position;
        collider.radius = radius;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        move();
        out_range_process();
        /*raycastを使った衝突判定開始*/
        CF_pos = transform.position;
        dir = (CF_pos - LF_pos).normalized;
        dis = Vector2.Distance(CF_pos,LF_pos);
    
        if(hit = Physics2D.CircleCast(CF_pos,radius,-dir, dis))
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                Destroy(gameObject);    
                hit.collider.gameObject.SendMessage("hit");
            }
        }
        LF_pos = CF_pos;
        /*raycastを使った衝突判定終了*/
    }
    public virtual void initialize()
    {


    }

    public virtual void move()
    {


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
        
        if(collision.gameObject.CompareTag("Player")) 
        {
            collision.gameObject.SendMessage("hit");
            Destroy (gameObject);
        }
        else if(collision.gameObject.CompareTag("slash"))
        {
            Destroy (gameObject);
        }
    }
}
