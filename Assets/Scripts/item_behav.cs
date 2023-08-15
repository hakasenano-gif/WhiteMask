using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_behav : MonoBehaviour {
  public class range {
    public float min, max;
    public range() {
      min = max = 0.0f;
    }
    public range(float arg1, float arg2) {
      min = arg1;
      max = arg2;
    }
  }

  public int ItemID = -1;
  public List<Sprite> ItemImages = new List<Sprite>();

  private range Xrange = new range();
  private range Yrange = new range();
  private float WaitTime = 1.0f;
  private float GetThres = 5.0f;
  private int MaxItems = 5;
  private GameObject PlayerGO;
  private Vector3 Dest = new Vector3(0.0f, 0.0f, 0.0f);
  private float PassedTime = 0.0f;

  void Start() {
    GameObject[] ItemGOs = GameObject.FindGameObjectsWithTag("Item");
    PlayerGO = GameObject.Find("Player");
    Xrange.min = Camera.main.ViewportToWorldPoint(Vector2.zero).x;
    Yrange.min = Camera.main.ViewportToWorldPoint(Vector2.zero).y;
    Xrange.max = Camera.main.ViewportToWorldPoint(Vector2.one).x;
    Yrange.max = Camera.main.ViewportToWorldPoint(Vector2.one).y;
    Dest[0] = (Xrange.max - Xrange.min) * RandomRate() + Xrange.min;
    Dest[1] = (Yrange.max - Yrange.min) * RandomRate() + Yrange.min;
    if (ItemImages.Count == 0) {
      Debug.Log("Specify Images of item.");
      Destroy(gameObject);
    } else {
      if (ItemID < 0 || ItemID >= ItemImages.Count) {
        gameObject.GetComponent<SpriteRenderer>().sprite = ItemImages[RandomValue(1, ItemImages.Count) - 1];
      } else {
        gameObject.GetComponent<SpriteRenderer>().sprite = ItemImages[ItemID];
      }
    }
    if (ItemGOs.Length > MaxItems) {
      Destroy(gameObject);
    }
  }

  void FixedUpdate() {
    if (ItemImages.Count > 0) {
      RandomMove();
      CheckPlayerDist();
    }
  }

  float RandomRate() {
    return Random.Range(0.0f, 1.0f);
  }

  int RandomValue(int min, int max) {
    return Random.Range(min, max + 1);
  }

  float RandomValue(float min, float max) {
    return Random.Range(min, max);
  }

  float Dist(Vector3 a, Vector3 b) {
    float dx = (a.x - b.x) * (a.x - b.x);
    float dy = (a.y - b.y) * (a.y - b.y);
    return dx + dy;
  }

  void RandomMove() {
    if (Dist(this.transform.position, Dest) < 1.0f) {
      if (PassedTime > WaitTime) {
        Dest[0] = (Xrange.max - Xrange.min) * RandomRate() + Xrange.min;
        Dest[1] = (Yrange.max - Yrange.min) * RandomRate() + Yrange.min;
        PassedTime = 0.0f;
      } else {
        PassedTime += Time.deltaTime;
      }
    } else {
      this.transform.position += (Dest - this.transform.position) * RandomValue(0.1f, 0.3f) * Time.deltaTime;
    }
  }

  void CheckPlayerDist() {
    if (Dist(this.transform.position, PlayerGO.transform.position) < GetThres) {
      switch (ItemID) {
        case 0:
          PlayerGO.GetComponent<player_controller>().SpeedUp(0.5f);
          break;
      }
      Destroy(gameObject);
    }
  }
}

