using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGage : MonoBehaviour {
  public string BossName;

  private GameObject BossGO;
  private List<GameObject> LifeGageGO = new List<GameObject>();
  private float BossLifeMax;
  private Vector3 LifeGageBase;
  private Vector3 LifeGageScaleBase;
  private float LifeGageXSize;

  void Start() {
    BossGO = GameObject.Find(BossName);
    LifeGageGO.Add(GameObject.Find("LifeGage"));
    LifeGageGO[0].GetComponent<SpriteRenderer>().color = Color.magenta;
    LifeGageBase = LifeGageGO[0].transform.position;
    LifeGageScaleBase = LifeGageGO[0].transform.localScale;
    LifeGageXSize = LifeGageGO[0].GetComponent<SpriteRenderer>().bounds.size.x;
    if (BossGO) {
      BossLifeMax = (float)BossGO.GetComponent<Enemy>().hp;
    } else {
      Destroy(gameObject);
    }
  }

  void Update() {
    float BossLifeRate;
    if (BossGO) {
      BossLifeRate = (float)BossGO.GetComponent<Enemy>().hp / BossLifeMax;
      LifeGageGO[0].transform.localScale = new Vector3(LifeGageScaleBase.x * BossLifeRate, LifeGageScaleBase.y, LifeGageScaleBase.z);
      LifeGageGO[0].transform.position = LifeGageBase + new Vector3(LifeGageXSize * (BossLifeRate - 1.0f) / 2, 0.0f, 0.0f);
    }
  }
}