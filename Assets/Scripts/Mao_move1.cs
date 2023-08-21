using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mao_move1 : MonoBehaviour
{
    public int hp;
    private int BossScore = 10000;
    private float bossBattleTime; // ボス戦の経過時間
    private float bossStartTime;
    public float teleportInterval = 5f; // 瞬間移動の間隔（秒）

    private float teleportRangeX = 7.5f; // X方向の瞬間移動範囲
    private float teleportRangeY = 2.5f; // Y方向の瞬間移動範囲
    private float minimumDistanceFromPlayer = 1.5f; // プレイヤーからの最低限の距離

    private Camera mainCamera;
    private GameObject playerObject; // プレイヤーのGameObject
    private GameObject gameManager;  // GameManager の参照

    public GameObject bulletPrefab; // プレハブから設定する弾のPrefab
    public float bulletSpeed = 0.1f; // 弾の移動速度
    public int bulletCount = 5; // 生成する弾の数

    private void Start()
    {
        mainCamera = Camera.main;
        playerObject = GameObject.FindGameObjectWithTag("Player");

	// ボス戦の開始時刻を記録
        bossBattleTime = Time.time;
        bossStartTime = Time.time;

	// GameManager のオブジェクトを取得
        gameManager = GameObject.Find("Gamemanager");

        // 一定間隔で瞬間移動を開始
        InvokeRepeating("TeleportToRandomLocation", teleportInterval, teleportInterval);
    }

    private void Update()
    {
        bossBattleTime = Time.time - bossStartTime;
    }
    private void StartShooting()
    {
        // 0.5秒ごとに5回射撃するコルーチンを開始
        StartCoroutine(ShootBulletCoroutine());
    }

    private void TeleportToRandomLocation()
    {
            // 画面中心(0, 0)からランダムな位置を生成
            Vector3 randomPosition = new Vector3(
                Random.Range(-teleportRangeX, teleportRangeX),
                Random.Range(-teleportRangeY, teleportRangeY),
                transform.position.z
            );

            // プレイヤーからの距離をチェック
            Vector3 playerPosition = playerObject.transform.position;
            float distanceFromPlayer = Vector3.Distance(playerPosition, randomPosition);
            while (distanceFromPlayer < minimumDistanceFromPlayer)
            {
                randomPosition = new Vector3(
                    Random.Range(-teleportRangeX, teleportRangeX),
                    Random.Range(-teleportRangeY, teleportRangeY),
                    transform.position.z
                );
                distanceFromPlayer = Vector3.Distance(playerPosition, randomPosition);
            }

            // 位置が画面外に行った場合はエラーログを表示
            if (!IsPositionWithinScreen(randomPosition))
            {
                Debug.LogError("瞬間移動エラー：ランダムな位置が画面外になりました");
            }
            else
            {
                // 位置を更新して瞬間移動
                transform.position = randomPosition;
            }

	// テレポートの3秒後に射撃を開始
        Invoke("StartShooting", 3f);

        }

    private bool IsPositionWithinScreen(Vector3 position)
    {
        // 与えられた位置が画面内かどうかをチェック
        float screenHeight = mainCamera.orthographicSize;
        float screenWidth = screenHeight * mainCamera.aspect;

        return (position.x >= -screenWidth && position.x <= screenWidth &&
                position.y >= -screenHeight && position.y <= screenHeight);
    }

    private IEnumerator ShootBulletCoroutine()
    {
        int shotCount = 0;
        while (shotCount < 5)
        {
            // 弾をプレイヤーの方向に発射する
            Vector3 playerPosition = playerObject.transform.position;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Vector3 direction = (playerPosition - transform.position).normalized;
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

            shotCount++;

            // 0.3秒待つ
            yield return new WaitForSeconds(0.3f);
        }
    }

    public void hit()
	{
		if (hp>=2) hp-=1;
		else 
		{
			Destroy(gameObject);

			// ボス戦の戦闘時間に応じてスコア変動
            float battleBonus = 100 * (100 - bossBattleTime);
            if(battleBonus <= 0) battleBonus = 0;
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
