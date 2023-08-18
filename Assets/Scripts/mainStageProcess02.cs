using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mainStageProcess02 : MonoBehaviour
{	
	public GameObject mob_poisonSlime;
	public GameObject mob_mermaid;
	public GameObject mob_jellyfish;
	public GameObject mob_fairy;
    public GameObject Gamemanager_obj;


	public float nextEnemySpawnTime;
	public float stage_time;

	[SerializeField]private float enemySpawnRate = 2.4f;	

	private gamemanager Gamemanager;

    void Awake()
    {
    Gamemanager_obj = GameObject.Find("Gamemanager");
    Gamemanager = Gamemanager_obj.GetComponent<gamemanager>();
    }
	void Start()
	{	
		nextEnemySpawnTime = enemySpawnRate;
		
    }


    void FixedUpdate()
	{
		if (Gamemanager.stage_time > 0)
		{
			nextEnemySpawnTime -=Time.deltaTime;

			if(nextEnemySpawnTime < 0)
			{	
				spawn_event(Random.Range(0,4));
				/*0から3までの範囲をとる*/
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
		switch (event_number)
		{
			case 0:
				Instantiate (mob_poisonSlime, new Vector3(random_x,-Gamemanager.MoveRange_y,transform.position.z) , Quaternion.identity);
				break;
			case 1:
				Instantiate (mob_jellyfish, new Vector3(random_x, random_y,transform.position.z) , Quaternion.identity);
				break;
			case 2:
				Instantiate (mob_mermaid, new Vector3(random_x,-Gamemanager.MoveRange_y,transform.position.z) , Quaternion.identity);
				break;
			case 3:
				Instantiate (mob_fairy, new Vector3(random_x, Mathf.Abs(random_y),transform.position.z) , Quaternion.identity);
				Instantiate (mob_fairy, new Vector3(random_x, 0,transform.position.z) , Quaternion.identity);
				Instantiate (mob_fairy, new Vector3(random_x, -Mathf.Abs(random_y),transform.position.z) , Quaternion.identity);
				break;
		}
	}


}





