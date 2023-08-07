using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class mob_balloonSkeletonChild : MonoBehaviour
{
    public GameObject ObjectParent;
    private Animator animator; 
    private int hp = 3;
    private float breakAnimeTime = 0.3f;

    public void Start()
    {       
        animator = GetComponent<Animator>();
    }

 	public void hit()
    {
        if(hp >=2) hp-=1;
        else 
        {
            StartCoroutine("balloonbreak");
        }
    }

    public void hit_slash()
    {
            StartCoroutine("balloonbreak");
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player")) 
        {
            if(this.tag!="broken") collision.gameObject.SendMessage("hit");
        }
	}
    IEnumerator balloonbreak()
    {
        ObjectParent.SendMessage("balloonBreak");
        animator.SetBool("BalloonBreak", true);
        this.tag = "broken";
        transform.SetParent(null);
        yield return new WaitForSeconds(breakAnimeTime);
        animator.SetBool("FinishBreakAnimation",true);
        Destroy(gameObject);
    }
}
