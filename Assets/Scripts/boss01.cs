using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class  boss: MonoBehaviour
{
	
	public int hp;
	private int attackPattern;
	private float nextfire;
	public float time;
	public Rigidbody2D rb;
 	
    // Start is called before the first frame update
    void Start()
    {
	CircleCollider2D collider = GetComponent<CircleCollider2D> ();
	Rigidbody2D rb = GetComponent<Rigidbody2D>();
	Time.timeScale = 0;
	StartCoroutine("bossAppear");
    }

    // Update is called once per frame

    void FixedUpdate()
    {		
		

	    /*発射処理*/
		{
	
			attackPattern = Random.Range(1,5);
			switch (attackPattern)
			{
				case 1:
					StartCoroutine("attack01");
					break;
				case 2:
					StartCoroutine("attack02");
					break;
				case 3:
					StartCoroutine("attack03");
					break;
				case 4:
					StartCoroutine("attack04");
					break;
			}
	    }
	 
    }
	IEnumerator bossAppear ()
	{
		yield return null;
		Time.timeScale = 1;
	}

	IEnumerator attack01()
	{
		yield return null;
	}

	IEnumerator attack02()
	{
		yield return null;
	}

	IEnumerator attack03()
	{
		yield return null;
	}

	IEnumerator attack04()
	{
		yield return null;
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
}