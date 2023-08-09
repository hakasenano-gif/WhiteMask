/*
編集履歴

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gamemanager : MonoBehaviour
{	
	public AudioClip player_death;
	public AudioClip bgm_main1;
	public AudioClip bgm_main2;
	public AudioClip bgm_main3;
	public AudioClip bgm_boss1;
	public AudioClip bgm_boss2;
	public AudioClip bgm_boss3;
	public AudioClip bgm_title;
	public AudioClip bgm_ending;
	private AudioSource audioSource_se;
	private AudioSource bgm;

	public GameObject GameoverPrint;
	public GameObject PrintStageNum;
	public GameObject PauseMenu;
	public GameObject PrintNowScore;
	public GameObject SwordGauge;
	public GameObject PrintSwordGauge;
	public GameObject PrintLimitTime;
	public GameObject Ending;
	public GameObject PrintGameResult;
	public static gamemanager instance;	
	public int Score = 0;
	public int PC_Life;
	public float stage_time_max = 60f;
	public int PC_Life_MAX = 3;
	public float stage_time;
	public float MoveRange_y = 4.5f;
	public bool Is_paused = false;
	public bool boss_appeared = false;
	public bool canPauseGame = true;
	public bool Is_Title;
	

	void Awake()
    {
        if(instance == null) instance = this;
        else                 Destroy (gameObject);
		DontDestroyOnLoad(gameObject);
		bgm = GetComponent<AudioSource>();
		audioSource_se = GetComponent<AudioSource>();
		bgm.clip = bgm_title;

    }

	void Start()
	{	
		bgm.Play();
		PauseMenu.SetActive(true);
		GameoverPrint.SetActive(true);
		PauseMenu.SetActive(false);
		GameoverPrint.SetActive(false);

		stage_time = stage_time_max;
		PC_Life = PC_Life_MAX;
		Instantiate (PrintStageNum, new Vector3(0,0,0) , Quaternion.identity);
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
		if ((stage_time > 0)&&Is_Title == false)
		{
			stage_time -= Time.deltaTime;		
		}
	}

	

/*ボスシーン*/
	void BossStageProcess()
	{
		/*
		SceneManager.LoadScene("MainScene2");
		boss_appeared = false;
		*/
	}

	void gamePause()
	{
		
		if((Input.GetKeyDown(KeyCode.Escape))&&(canPauseGame==true))		
		{
			if(Is_paused == false)
			{
				BGMPause();
				PauseMenu.SetActive(true);
				Time.timeScale = 0;
				Is_paused = true;
			}
			else 
			{
				BGMUnPause();
				PauseMenu.SetActive(false);
				Time.timeScale = 1f;
				Is_paused = false;
				
			}
		} 
	}


    public void BGMPause()
    {
        bgm.Pause();
    }

	public void BGMUnPause()
	{
        bgm.UnPause();
    }

	

	IEnumerator Initialize()
	{
		Score = 0;
		PC_Life = PC_Life_MAX;
		stage_time = stage_time_max;
		Is_paused = false;
		boss_appeared = false;
		Time.timeScale = 1;
		yield return null;
	}

	public IEnumerator onPlayerDeath()
	{
		Is_paused = true;
		canPauseGame = false;
		audioSource_se.PlayOneShot(player_death);
		yield return new WaitForSeconds(0.5f);
		GameoverPrint.SetActive(true);
		Time.timeScale = 0;


	}

	public void TimeUp_Main()
	{
		
		stage_time = stage_time_max;
		boss_appeared = true;
		if(SceneManager.GetActiveScene().name == "MainScene1")
		{
        	SceneManager.LoadScene("BossScene1");
		}

		if(SceneManager.GetActiveScene().name == "MainScene2")
		{
			SceneManager.LoadScene("BossScene2");
		}

		if(SceneManager.GetActiveScene().name == "MainScene3")
		{
			SceneManager.LoadScene("BossScene3");
		}
		StartCoroutine("SceneLoad");
	}

	public void Boss_Defeated()
	{
		/*ボスを倒した際にこの関数を呼び出す*/
		boss_appeared = false;
		if(SceneManager.GetActiveScene().name == "BossScene1")
		{
        	SceneManager.LoadScene("MainScene2");
		}

		if(SceneManager.GetActiveScene().name == "BossScene2")
		{
			SceneManager.LoadScene("MainScene2");			
		}

		if(SceneManager.GetActiveScene().name == "BossScene3")
		{
			SceneManager.LoadScene("EndingScene");
			canPauseGame = false;
			Instantiate (Ending, new Vector3(0,0,0) , Quaternion.identity);
			Ending = GameObject.Find("Ending");
			StartCoroutine("stuffedRoll");
		}
		StartCoroutine("SceneLoad");
	}

	IEnumerator SceneLoad()
	{
		yield return null;
		Instantiate (PrintStageNum, new Vector3(0,0,0) , Quaternion.identity);
		switch(SceneManager.GetActiveScene().name)
		{
			case "MainScene1":
			{
				bgm.clip = bgm_main1;
				break;
			}
			case "MainScene2":
			{
				bgm.clip = bgm_main2;
				break;
			}
			case "MainScene3":
			{
				bgm.clip = bgm_main3;
				break;
			}
			case "BossScene1":
			{
				bgm.clip = bgm_boss1;
				break;
			}
			case "BossScene2":
			{
				bgm.clip = bgm_boss2;
				break;
			}
			case "BossScene3":
			{
				bgm.clip = bgm_boss3;
				break;
			}
			case "TitleScene":
			{
				bgm.clip = bgm_title;
				break;
			}
			case "EndingScene":
			{
				bgm.clip = bgm_ending;
				break;
			}

		}
		bgm.Play();
	}

	IEnumerator stuffedRoll()
	{
		yield return null;
		while(Ending != null)
		{
			yield return null;
		}
		Instantiate (PrintGameResult, new Vector3(0,0,0) , Quaternion.identity);	
	}

	IEnumerator ResumeGame()
	{
		BGMUnPause();
		yield return null;
		PauseMenu.SetActive(false);
		Time.timeScale = 1;
		Is_paused = false;
		
	}

	IEnumerator Retry()
	{

		PauseMenu.SetActive(false);
		GameoverPrint.SetActive(false);
		yield return null;
		SceneManager.LoadScene("MainScene1");
		StartCoroutine("Initialize");
		canPauseGame = true;
		StartCoroutine("SceneLoad");
	}
	IEnumerator GoToTitle()
	{
		Is_Title = true;
		PrintNowScore.SetActive(false);
		SwordGauge.SetActive(false);
		PrintLimitTime.SetActive(false);
		PauseMenu.SetActive(false);
		GameoverPrint.SetActive(false);
		yield return null;
		SceneManager.LoadScene("TitleScene");
		StartCoroutine("Initialize");
		canPauseGame = false;
		StartCoroutine("SceneLoad");
	}

	public void TitleToGame()
	{
		Is_Title = false;
		PrintNowScore.SetActive(true);
		SwordGauge.SetActive(true);
		PrintLimitTime.SetActive(true);
		SceneManager.LoadScene("MainScene1");
		StartCoroutine("Initialize");
		canPauseGame = true;
		StartCoroutine("SceneLoad");
	}

	public void ExitGame()
	{
		#if UNITY_EDITOR
      		UnityEditor.EditorApplication.isPlaying = false;
    	#else
      		Application.Quit();
    	#endif
	}

	public void AddScore(int EnemyScore)
	{
		Score += EnemyScore;
	}

	public void AddTime(float Time)
	{
		stage_time += Time;
	}

	public void HP_Up(int life)
	{
		PC_Life += life;
	}

}
