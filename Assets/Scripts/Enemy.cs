/*編集履歴
最初にゲームマネージャーを探索する処理を追加
エネミー討伐時，score加算されるように変更
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class  Enemy: MonoBehaviour
{
	
	
	public int hp;
	public int Score;
	public int dropItemType;
	public  float firerate;
	public  float nextfire;
	public float size;
	public float time;
	private float spawn_range_x;
	private float spawn_range_y;
	public GameObject gamemanager;
	public GameObject enemy_death_effect;
	public Rigidbody2D rb;
	public AudioClip se_death;
    AudioSource audioSource;
 	
    // Start is called before the first frame update
    void Start()
    {
	audioSource = GetComponent<AudioSource>();
	gamemanager = GameObject.Find("Gamemanager");
	CircleCollider2D collider = GetComponent<CircleCollider2D> ();
	Rigidbody2D rb = GetComponent<Rigidbody2D>();
	this.tag = "enemy";
    initialize();
	collider.radius = size;
	collider.isTrigger = true;
	spawn_range_x = 12f;
	spawn_range_y = 10f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
			time+=Time.deltaTime;
			move();

	    /*発射処理*/
		if((nextfire>0)&&(transform.position.x>-9f)&&(transform.position.x<8.5f))  nextfire-=Time.deltaTime;
        if (nextfire<=0) 
	    {
		    attack();
    	    nextfire=firerate;
	    }
	 
		/*一定範囲の外に出た際に破壊する処理*/
	    if(transform.position.x > spawn_range_x||transform.position.x < -spawn_range_x||transform.position.y > spawn_range_y||transform.position.y < -spawn_range_y)
	    {
	        Destroy(gameObject);
	    }
    }


	public void hit()
	{
		if (hp > 1) hp-=1;
		else 
		{
			OnEnemyDeath();
			
		}
	}

	public void hit_slash()
	{
		if (hp>=16) hp-=15;
		else 
		{
			OnEnemyDeath();
		}
	}

 	public virtual void OnTriggerEnter2D(Collider2D collision)
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
	public virtual void move()
	{
	}

	public virtual void OnEnemyDeath()
	{
		
		Instantiate(enemy_death_effect, transform.position, Quaternion.Euler(0f, 0f, 0));
		gamemanager.SendMessage("AddScore",Score);
		int ramdomValue = Random.Range(0,101);
		switch(dropItemType)
		{
			case 0:
			{
				if(ramdomValue < 10)
				{
					/*アイテム1を落とす*/
				}
				else if((ramdomValue >10)&&((ramdomValue < 50)))
				{
					/*得点アイテムを落とす*/
				}
				break; 
			}
			case 1:
				break;
			case 2:
				break;

		}
		Destroy(gameObject);
	}
}