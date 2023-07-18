using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gamemanager : MonoBehaviour
{	
	public GameObject mob01;
	public GameObject mob02;
	public GameObject mob03;
	public GameObject mob04;

	public int difficulty;
	public float stage_time_max = 60f;
	public float enemy_spawn_timer_max;
	public bool Is_paused = false;
	[SerializeField]private float enemy_spawn_timer; 
	[SerializeField]private float stage_time;
	[SerializeField]private bool boss_appeared = false;
	[SerializeField]private bool boss_beaten = false;
	
	void Start()
	{	
		difficulty = 0;
		stage_time = stage_time_max;
		enemy_spawn_timer_max = 3f;
		enemy_spawn_timer = enemy_spawn_timer_max;
		
		
	}


	void Update()
	{
		gamePause();
	}

    void FixedUpdate()
	{
		enemySpawn();
	}

	void enemySpawn()
	{
		if (stage_time > 0)
		{
			stage_time -= Time.deltaTime;
			enemy_spawn_timer -=Time.deltaTime;

			if(enemy_spawn_timer < 0)
			{	
				spawn_event(4*difficulty+Random.Range(0,4));
				/*0から11までの範囲をとる

				Random.Rangeは第一引数<=x<第二引数の範囲の値を取るということに注意*/
				enemy_spawn_timer = enemy_spawn_timer_max;
			}				
			
		}
		else 
		{
			if (boss_appeared == false) {
			/*ボスを出す*/
			boss_appeared = true;
			}
			else if (boss_appeared == true) /*ボスが倒された*/
			boss_appeared = false;
			boss_beaten   = false;
			stage_time    = stage_time_max;
			difficulty   += 1;
		}
	}

	void spawn_event(int event_number)
	{
		float random_x = Random.Range(9,12);
		float random_y = Random.Range(-4.5f,4.5f);
		switch (event_number)
		{
			case 0:
				Instantiate (mob01, new Vector3(random_x,random_y,transform.position.z) , Quaternion.identity);
				break;
			case 1:
				Instantiate (mob02, new Vector3(random_x,random_y,transform.position.z) , Quaternion.identity);
				break;
			case 2:
				Instantiate (mob03, new Vector3(random_x,random_y,transform.position.z) , Quaternion.identity);
				break;
			case 3:
				Instantiate (mob04, new Vector3(random_x,random_y,transform.position.z) , Quaternion.identity);
				break;
			case 4:
				break;
			case 5:
				break;
			case 6:
				break;
			case 7:
				break;
			case 8:
				break;
			default:
				break;
		}


	}	
	void gamePause()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(Is_paused == false)
			{
				Time.timeScale = 0;
				Is_paused = true;
			}
			else 
			{
				Time.timeScale = 1;
				Is_paused = false;
			}
		} 
	}
}





