using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class mob_demon : Enemy
{

	[SerializeField]private float speed = 0.01f;
	public GameObject bullet_demon1;
	public GameObject bullet_demon2;
	public GameObject target;
	private gamemanager Gamemanager;

	public float move_y;
	public bool Is_rising;

	
	public override void initialize()
	{
		hp = 15;
		firerate = 3f;
		nextfire = 6f;
		size = 2.2f;
		Score = 2500;
		StartCoroutine ("fastshoot");
		StartCoroutine ("return_right");
		Gamemanager = gamemanager.GetComponent<gamemanager>();
	}
	public override void attack()
	{
		Instantiate (bullet_demon1, transform.position, Quaternion.Euler(0f, 0f,-75));
		Instantiate (bullet_demon1, transform.position, Quaternion.Euler(0f, 0f,-60));
		Instantiate (bullet_demon1, transform.position, Quaternion.Euler(0f, 0f,-45));
		Instantiate (bullet_demon1, transform.position, Quaternion.Euler(0f, 0f,-30));
		Instantiate (bullet_demon1, transform.position, Quaternion.Euler(0f, 0f,-15));
		Instantiate (bullet_demon1, transform.position, Quaternion.Euler(0f, 0f,0));
		Instantiate (bullet_demon1, transform.position, Quaternion.Euler(0f, 0f,15));
		Instantiate (bullet_demon1, transform.position, Quaternion.Euler(0f, 0f,30));
		Instantiate (bullet_demon1, transform.position, Quaternion.Euler(0f, 0f,45));
		Instantiate (bullet_demon1, transform.position, Quaternion.Euler(0f, 0f,60));
		Instantiate (bullet_demon1, transform.position, Quaternion.Euler(0f, 0f,75));
		
	}
		

	public override void move()
	{
		limitate_move_range();
		if(Is_rising == true) move_y += 0.003f;
		else move_y -=0.003f;
		if(move_y > 0.07f)  Is_rising = false;
		if(move_y < -0.07f) Is_rising = true;

		transform.Translate(-speed,move_y,0);
	}

	public void limitate_move_range()
	{
		float y = Mathf.Clamp(transform.position.y,-Gamemanager.MoveRange_y,Gamemanager.MoveRange_y);        
		transform.position=new Vector3(transform.position.x,y,transform.position.z);
    }

	IEnumerator fastshoot()
	{
		while(true)
		{
			yield return new WaitForSeconds(2.5f);
			Instantiate (bullet_demon2, transform.position,Quaternion.Euler(0f, 0f,0f));
		}
	}

	IEnumerator return_right()
	{
		yield return new WaitForSeconds(20f);
		speed = -0.2f;

	}
}	