using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class bullet_grimReaper : MonoBehaviour
{
    public string targetTag = "Player";
    public GameObject target;

    private Animator animator; 
    public float time_to_delete;
    private float time_to_delete_max = 0.2f;
    public void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag);
        BoxCollider2D collider = GetComponent<BoxCollider2D> ();
        collider.isTrigger = true;
        time_to_delete = time_to_delete_max;
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(time_to_delete > 0)
        {
            time_to_delete -= Time.deltaTime;
        }
        else 
        {
            time_to_delete = time_to_delete_max;
            animator.SetBool("slashing", false);
            gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag(targetTag)) 
        {
            collision.gameObject.SendMessage("hit");
        
        }
    }

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("slashing", true);
    }

}