using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doragon_move : MonoBehaviour
{  
    public int hp;
    private int BossScore = 10000;
    private float bossBattleTime; // ボス戦の経過時間
    private float bossStartTime;
    public float moveSpeed = 5f;
    public float attackInterval = 2f;
    public float attackDuration = 1f; // 攻撃の持続時間
    public float preAttackDelay = 1f; // 攻撃前の停止時間
    public GameObject Dragon_bulletPrefab;

    private Vector3 targetPosition;
    private float timeSinceLastAttack = 0f;
    private bool isAttacking = false;
    private GameObject playerObject;
    private GameObject gameManager;

    void Start()
    {
	// GameManager のオブジェクトを取得
       gameManager = GameObject.Find("Gamemanager");

	// ボス戦の開始時刻を記録
        bossBattleTime = Time.time;
        bossStartTime = Time.time;

        // 初期位置をランダムに設定
        SetRandomTargetPosition();

	// プレーヤーオブジェクトをタグで検索して取得
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
    bossBattleTime = Time.time - bossStartTime;
    }
    
    void FixedUpdate()
    {
        if (!isAttacking)
        {
            MoveTowardsTarget();
        }

        timeSinceLastAttack += Time.deltaTime;

        if (!isAttacking && timeSinceLastAttack >= attackInterval)
        {
            StartAttack();
        }

        if (isAttacking && timeSinceLastAttack >= attackDuration)
        {
            StopAttack();
        }
    }

    void MoveTowardsTarget()
    {
        // ターゲット位置に向かって移動
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // ターゲット位置に到達したら、新しいターゲット位置を設定
        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
        {
            SetRandomTargetPosition();
        }
    }

    void SetRandomTargetPosition()
    {
        // 画面内のランダムな位置を選ぶ
        float x = Random.Range(-8f, 8f);
        float y = Random.Range(-2f, 4.5f);
        targetPosition = new Vector3(x, y, 0f);
    }

    void StartAttack()
    {
        isAttacking = true; // 攻撃フラグをオンにする
        timeSinceLastAttack = 0f; // 攻撃前の停止時間をリセット

        // 攻撃前の停止時間後に攻撃を開始する
        Invoke("Attack", preAttackDelay);
    }

    void Attack()
    {
        // プレーヤーオブジェクトの位置に向かって攻撃を行う
        if(playerObject != null)
        {
            Vector3 directionToPlayer = (playerObject.transform.position - transform.position).normalized;
            GameObject Dragon_bullet = Instantiate(Dragon_bulletPrefab, transform.position, Quaternion.identity);
            Dragon_bullet.GetComponent<Rigidbody2D>().velocity = directionToPlayer * 10f; // 攻撃速度を設定（仮に10fとします）
        }
    }

    void StopAttack()
    {
        isAttacking = false; // 攻撃フラグをオフにする
    }

	public void hit()
	{
		if (hp>=2) hp-=1;
		else 
		{
			Destroy(gameObject);

			// ボス戦の戦闘時間に応じてスコア変動
            float battleBonus = 100 * (100 - bossBattleTime);
            if(battleBonus <=0 ) battleBonus = 0;
			int Score = Mathf.FloorToInt(BossScore + battleBonus);

			gameManager.SendMessage("AddScore",Score);
			gameManager.SendMessage("Boss_Defeated");
		}
	}

	public void hit_slash()
	{
		if (hp>=16) hp-=15;
		else 
		{
			Destroy(gameObject);

			// ボス戦の戦闘時間に応じてスコア変動
            float battleBonus = 100 * (100 - bossBattleTime);
            if(battleBonus <=0 ) battleBonus = 0;
			int Score = Mathf.FloorToInt(BossScore + battleBonus);

			gameManager.SendMessage("AddScore",Score);
			gameManager.SendMessage("Boss_Defeated");
		}
	}

 	public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player")) 
        {
            collision.gameObject.SendMessage("hit");
        }
	}

}
