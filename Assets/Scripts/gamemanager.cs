/*
編集履歴
変数名の変更(enemy_spawn_timerとenemy_spawn_timer_max
をそれぞれnextEnemySpawnTimeとenemySpawnRateに変更)

nextEnemySpawnTimeとstage_timeをパブリック変数に，
enemySpawnRateとstage_time_maxをプライベート変数に変更

シングルトンの導入
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gamemanager : MonoBehaviour
{	
	public static gamemanager instance;
	public GameObject mob01;
	public GameObject mob02;
	public GameObject mob03;
	public GameObject mob04;
	public float nextEnemySpawnTime;
	public float stage_time;
	public bool Is_paused = false;

	[SerializeField]private int difficulty = 0;
	[SerializeField]private float stage_time_max = 60f;
	[SerializeField]private float enemySpawnRate = 3f;	
	[SerializeField]private bool boss_appeared = false;

	void Awake()
    {
        if(instance == null) instance = this;
        else                 Destroy (gameObject);
		DontDestroyOnLoad(gameObject);
    }


	void Start()
	{	

		difficulty = 0;
		stage_time = stage_time_max;
		nextEnemySpawnTime = enemySpawnRate;
		
		
	}

/*Update関数にはプレイヤーの操作を受け付けて何らかの処理を行うもの，FixedUpdate関数には
プレイヤーの操作に関わらず処理するものを記述するのが望ましい
Pause関数でタイムスケールをゼロにして，ゲームをポーズできるようにしているが，
Update関数内のものはこの値に関わらず動く．*/

	void Update()
	{
		gamePause();
	}

    void FixedUpdate()
	{
		if(boss_appeared == false) MainStageProcess();
		else 					  BossStageProcess();
	}

	void MainStageProcess()
	{
		if (stage_time > 0)
		{
			stage_time -= Time.deltaTime;
			nextEnemySpawnTime -=Time.deltaTime;

			if(nextEnemySpawnTime < 0)
			{	
				spawn_event(4*difficulty+Random.Range(0,4));
				/*0から11までの範囲をとる

				Random.Rangeは第一引数<=x<第二引数の範囲の値を取るということに注意*/
				nextEnemySpawnTime = enemySpawnRate;
			}				
			
		}
		else 
		{
			stage_time = stage_time_max;
			difficulty += 1;
			boss_appeared = true;
			SceneManager.LoadScene("BossScene");
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

/*ボスシーン*/
	void BossStageProcess()
	{



		SceneManager.LoadScene("MainScene");
		boss_appeared = false;
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
