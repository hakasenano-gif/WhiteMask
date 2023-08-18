using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mainStageProcess03 : MonoBehaviour
{	
	public GameObject mob_ghostParent;
	public GameObject mob_grimReaper;
	public GameObject mob_demon;
    public GameObject Gamemanager_obj;


	public float nextEnemySpawnTime;
	public float stage_time;

	[SerializeField]private float enemySpawnRate = 2.0f;	

	private gamemanager Gamemanager;

    void Awake()
    {
    Gamemanager_obj = GameObject.Find("Gamemanager");
    Gamemanager = Gamemanager_obj.GetComponent<gamemanager>();
    }
	void Start()
	{	
		nextEnemySpawnTime = enemySpawnRate;
		StartCoroutine("spawnDemon");
    }


    void FixedUpdate()
	{
		if (Gamemanager.stage_time > 0)
		{
			nextEnemySpawnTime -=Time.deltaTime;

			if(nextEnemySpawnTime < 0)
			{	
				spawn_event(Random.Range(0,11));
				/*0から10までの範囲をとる*/
				nextEnemySpawnTime = enemySpawnRate;
			}				
			
		}
		else 
		{
			Gamemanager.TimeUp_Main();
		}
	}

	void spawn_event(int event_number)
	{
		float random_x = Random.Range(9,12);
		float random_y = Random.Range(-4.5f,4.5f);
		switch (event_number/5)
		{
			case 0:
				Instantiate (mob_ghostParent, new Vector3(random_x,Mathf.Abs(random_y),transform.position.z) , Quaternion.identity);
				Instantiate (mob_ghostParent, new Vector3(random_x,-Mathf.Abs(random_y),transform.position.z) , Quaternion.identity);
				break;
			case 1:
				Instantiate (mob_grimReaper, new Vector3(random_x, random_y,transform.position.z) , Quaternion.identity);
				break;
			case 2:
				Instantiate (mob_demon, new Vector3(random_x,random_y,transform.position.z) , Quaternion.identity);
				break;
		}
	}

	IEnumerator spawnDemon()
	{
		yield return new WaitForSeconds(20);
		Instantiate (mob_demon, new Vector3(9,0,transform.position.z) , Quaternion.identity);
		yield return new WaitForSeconds(20);
		Instantiate (mob_demon, new Vector3(9,0,transform.position.z) , Quaternion.identity);
	}


}





