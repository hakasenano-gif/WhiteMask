using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class mob_grimReaper : Enemy
{
	public GameObject bullet_grimReaper;
	public Sprite baseSprite;
	public Sprite slash;
    private SpriteRenderer spriteRenderer;
	public float speed = 0.01f;
	public float slash_time = 0.2f;
	


	public GameObject target;
	
	public override void initialize()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		target = GameObject.Find("Player");
		hp = 15;
		firerate = 5f;
		nextfire = 1.5f;
		size = 2.1f;
		Score = 1500;
		
		
	}
	public override void attack()
	{
		StartCoroutine ("teleportAndAttack");
	}

	public override void move()
	{
		if(transform.position.x>=8.5)
		transform.Translate(-speed,0,0);
	}
	IEnumerator teleportAndAttack()
	{
		if(target!=null)
		transform.position = new Vector2 (target.transform.position.x + 3f,target.transform.position.y);
		yield return new WaitForSeconds(0.5f);
		spriteRenderer.sprite = slash;
		bullet_grimReaper.SetActive(true);
		yield return new WaitForSeconds(slash_time);
		spriteRenderer.sprite = baseSprite;
	}


}	