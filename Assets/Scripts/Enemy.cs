using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class  Enemy: MonoBehaviour
{
	
	public int hp;
	public  float firerate;
	public float size;
	private  float nextfire;
	public float time;
	private float spawn_range_x;
	private float spawn_range_y;

	public Rigidbody2D rb;
 	
    // Start is called before the first frame update
    void Start()
    {
	CircleCollider2D collider = GetComponent<CircleCollider2D> ();
	Rigidbody2D rb = GetComponent<Rigidbody2D>();
	this.tag = "enemy";
    initialize();
	collider.radius = size;
	collider.isTrigger = true;
	spawn_range_x = 12f;
	spawn_range_y = 10f;
	rb.bodyType = RigidbodyType2D.Kinematic; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
			time+=Time.deltaTime;
			move(time);

	    /*発射処理*/
		if((nextfire<firerate)&&(transform.position.x>-9f)&&(transform.position.x<9f))  nextfire+=Time.deltaTime;
        if (nextfire>=firerate) 
	    {
		    attack();
    	    nextfire=0f;
	    }
	 
		/*一定範囲の外に出た際に破壊する処理*/
	    if(transform.position.x > spawn_range_x||transform.position.x < -spawn_range_x||transform.position.y > spawn_range_y||transform.position.y < -spawn_range_y)
	    {
	        Destroy(gameObject);
	    }
    }


	public void hit()
	{
		if (hp>=2) hp-=1;
		else 
		{
			Destroy(gameObject);
		}
	}

	public void hit_slash()
	{
		if (hp>=16) hp-=15;
		else 
		{
			Destroy(gameObject);
		}
	}

 	public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player")) 
        {
            collision.gameObject.SendMessage("hit");
        }
	}
	public virtual void initialize()
	{
	}
	public virtual void attack()
	{
	}
	public virtual void move(float t)
	{
	}


}