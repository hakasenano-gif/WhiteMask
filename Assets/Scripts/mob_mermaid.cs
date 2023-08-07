using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class mob_mermaid : Enemy
{
	[SerializeField]private float stopPos;
	[SerializeField]private float speed = 0.01f;
	public GameObject bullet_mermaid;

	public GameObject target;
	
	public override void initialize()
	{
		hp = 9;
		firerate = 5f;
		nextfire = 3f;
		size = 1f;
		Score = 800;
		stopPos = Random.Range(0.0f,8.5f);	
	}
	public override void attack()
	{
		Instantiate (bullet_mermaid, transform.position, Quaternion.identity);
		Instantiate (bullet_mermaid, transform.position, Quaternion.Euler(0f, 0f, -30f));
		Instantiate (bullet_mermaid, transform.position, Quaternion.Euler(0f, 0f, -60f));
		Instantiate (bullet_mermaid, transform.position, Quaternion.Euler(0f, 0f, -90f));
		Instantiate (bullet_mermaid, transform.position, Quaternion.Euler(0f, 0f, -120f));
		Instantiate (bullet_mermaid, transform.position, Quaternion.Euler(0f, 0f, -150f));
		Instantiate (bullet_mermaid, transform.position, Quaternion.Euler(0f, 0f, -180f));

	}
	public override void move()
	{
		if (transform.position.x > stopPos) transform.Translate(-speed,0,0);
	}

}	