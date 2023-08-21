using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Akuma_move : MonoBehaviour
{
    public int hp;
    private int BossScore = 10000;
    private float bossBattleTime; // ボス戦の経過時間
    private float bossStartTime;
    public float moveSpeed = 2.0f;               // ボスの移動速度
    public float jumpForce = 5.0f;               // ボスのジャンプ力
    public float minJumpCooldown = 1.0f;         // ジャンプクールダウンの最小時間
    public float maxJumpCooldown = 3.0f;         // ジャンプクールダウンの最大時間
    private float nextJumpTime = 0.0f;           // 次のジャンプの予定時間
    private Vector2 minPosition = new Vector2(-7.7f, -3.5f); // 移動制限範囲の最小座標
    private Vector2 maxPosition = new Vector2(7.7f, 3.5f);   // 移動制限範囲の最大座標
    private bool isMovingRight = true;

    private Rigidbody2D rb;
    private GameObject gameManager;  // GameManager の参照

    private void Start()
    {
	// ボス戦の開始時刻を記録
        bossBattleTime = Time.time;
        

	// GameManager のオブジェクトを取得
        gameManager = GameObject.Find("Gamemanager");
        rb = GetComponent<Rigidbody2D>();
        CalculateNextJumpTime();  // 初期のジャンプ時間を計算
    }

    private void Update()
    {
        bossBattleTime = Time.time - bossStartTime;
        if (Time.time >= nextJumpTime)
        {
            Jump();               // ジャンプ
            CalculateNextJumpTime();  // 次のジャンプ時間を計算
        }

        Move();                    // 移動
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // ボスをジャンプさせる
    }

    private void Move()
    {
	Vector3 currentPosition = transform.position;

	// ボスの位置を制限範囲内に収めて、スライド移動させる
	Vector2 newPosition = new Vector2(
    	    Mathf.Clamp(currentPosition.x + (isMovingRight ? 1 : -1) * moveSpeed * Time.deltaTime, minPosition.x, maxPosition.x),
    	    Mathf.Clamp(currentPosition.y, minPosition.y, maxPosition.y)
	);

    	transform.position = newPosition;  // ボスの位置を更新

    	// 画面端に到達したら移動方向を反転する
    	if (newPosition.x <= minPosition.x || newPosition.x >= maxPosition.x)
    	{
    	    isMovingRight = !isMovingRight;
    	}
    }

    private void CalculateNextJumpTime()
    {
        nextJumpTime = Time.time + Random.Range(minJumpCooldown, maxJumpCooldown); // 次のジャンプ時間をランダムに設定
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
