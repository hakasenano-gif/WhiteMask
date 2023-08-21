using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mao_bullet : MonoBehaviour
{
    public float speed = 0.0005f; // 弾の速さ

    private Vector3 direction; // 移動方向

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // プレイヤーオブジェクトの方向を取得
            direction = (player.transform.position - transform.position).normalized;
        }
        else
        {
            // プレイヤーオブジェクトが見つからない場合は弾を削除
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        // 画面外に出たら弾を削除
        if (!IsWithinScreen())
        {
            Destroy(gameObject);
        }
        else
        {
            // 移動処理
            transform.position += direction * speed;
        }
    }

    private bool IsWithinScreen()
    {
        // 画面内かどうかをチェック
        Camera mainCamera = Camera.main;
        float screenHeight = mainCamera.orthographicSize;
        float screenWidth = screenHeight * mainCamera.aspect;

        return (transform.position.x >= -screenWidth && transform.position.x <= screenWidth &&
                transform.position.y >= -screenHeight && transform.position.y <= screenHeight);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // グラウンドタグかプレイヤータグに衝突した場合は弾を削除
        if (collision.gameObject.CompareTag("Player"))
        {
	          collision.gameObject.SendMessage("hit");
            Destroy(gameObject);
        }
    }
}
