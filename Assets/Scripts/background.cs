using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour {
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

  public List<GameObject> BackgroundPrefabs = new List<GameObject>();

  private float Speed = 50.0f;
  private List<List<GameObject>> BackgroundGOs = new List<List<GameObject>>();
  private range Xrange = new range();
  private range Yrange = new range();
  private float Xsize, Ysize, Xbase, Ybase;

  void Start() {
    Xrange.min = Camera.main.ViewportToWorldPoint(Vector2.zero).x;
    Yrange.min = Camera.main.ViewportToWorldPoint(Vector2.zero).y;
    Xrange.max = Camera.main.ViewportToWorldPoint(Vector2.one).x;
    Yrange.max = Camera.main.ViewportToWorldPoint(Vector2.one).y;
    Xsize = Xrange.max - Xrange.min;
    Ysize = Yrange.max - Yrange.min;
    Xbase = Camera.main.transform.position.x;
    Ybase = Camera.main.transform.position.y;
    if (BackgroundPrefabs.Count == 0) {
      Debug.Log("Specify prefabs of background.");
    } else {
      for (int i = 0; i < BackgroundPrefabs.Count; i++) {
        List<GameObject> BackgroundGO = new List<GameObject>();
        BackgroundGO.Add(Object.Instantiate(BackgroundPrefabs[i]) as GameObject);
        BackgroundGO.Add(Object.Instantiate(BackgroundPrefabs[i]) as GameObject);
        BackgroundGOs.Add(BackgroundGO);
        BackgroundGOs[i][0].transform.position = new Vector3(Xbase + Xsize / 2, Ybase, 10.0f + i);
        BackgroundGOs[i][1].transform.position = new Vector3(Xbase - Xsize / 2, Ybase, 10.0f + i);
      }
    }
  }

  void Update() {
    if (BackgroundPrefabs.Count > 0) {
      ScrollBackgrounds();
    }
  }

  void ScrollBackgrounds() {
    for (int i = 0; i < BackgroundGOs.Count; i++) {
      for (int j = 0; j < BackgroundGOs[i].Count; j++) {
        BackgroundGOs[i][j].transform.position -= new Vector3(Speed, 0.0f, 0.0f) * Time.deltaTime;
        if (BackgroundGOs[i][j].transform.position.x > Xbase + Xsize) {
          BackgroundGOs[i][j].transform.position -= new Vector3(Xsize * 2, 0.0f, 0.0f);
        } else if (BackgroundGOs[i][j].transform.position.x < Xbase - Xsize) {
          BackgroundGOs[i][j].transform.position += new Vector3(Xsize * 2, 0.0f, 0.0f);
        }
        if (BackgroundGOs[i][j].transform.position.y > Ybase + Ysize) {
          BackgroundGOs[i][j].transform.position -= new Vector3(0.0f, Ysize * 2, 0.0f);
        } else if (BackgroundGOs[i][j].transform.position.y < Ybase - Ysize) {
          BackgroundGOs[i][j].transform.position += new Vector3(0.0f, Ysize * 2, 0.0f);
        }
      }
    }
  }
}

