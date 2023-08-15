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
  private range CamXrange = new range();
  private range CamYrange = new range();
  private float CamXsize, CamYsize, CamXbase, CamYbase, ObjScale, ObjXsize, ObjYsize;

  void Start() {
    CamXrange.min = Camera.main.ViewportToWorldPoint(Vector2.zero).x;
    CamYrange.min = Camera.main.ViewportToWorldPoint(Vector2.zero).y;
    CamXrange.max = Camera.main.ViewportToWorldPoint(Vector2.one).x;
    CamYrange.max = Camera.main.ViewportToWorldPoint(Vector2.one).y;
    CamXsize = CamXrange.max - CamXrange.min;
    CamYsize = CamYrange.max - CamYrange.min;
    CamXbase = Camera.main.transform.position.x;
    CamYbase = Camera.main.transform.position.y;
    if (BackgroundPrefabs.Count == 0) {
      Debug.Log("Specify prefabs of background.");
    } else {
      for (int i = 0; i < BackgroundPrefabs.Count; i++) {
        List<GameObject> BackgroundGO = new List<GameObject>();
        BackgroundGO.Add(Object.Instantiate(BackgroundPrefabs[i]) as GameObject);
        BackgroundGO.Add(Object.Instantiate(BackgroundPrefabs[i]) as GameObject);
        BackgroundGOs.Add(BackgroundGO);
        ObjScale = CamYsize / BackgroundGOs[i][0].GetComponent<animation>().Images[0].bounds.size.y;
        ObjXsize = BackgroundGOs[i][0].GetComponent<animation>().Images[0].bounds.size.x * ObjScale;
        ObjYsize = BackgroundGOs[i][0].GetComponent<animation>().Images[0].bounds.size.y * ObjScale;
        BackgroundGOs[i][0].GetComponent<animation>().Scale = ObjScale;
        BackgroundGOs[i][1].GetComponent<animation>().Scale = ObjScale;
        BackgroundGOs[i][0].transform.position = new Vector3(CamXbase + ObjXsize / 2, CamYbase, 10.0f + i);
        BackgroundGOs[i][1].transform.position = new Vector3(CamXbase - ObjXsize / 2, CamYbase, 10.0f + i);
      }
    }
  }

  void FixedUpdate() {
    if (BackgroundPrefabs.Count > 0) {
      ScrollBackgrounds();
    }
  }

  void ScrollBackgrounds() {
    for (int i = 0; i < BackgroundGOs.Count; i++) {
      for (int j = 0; j < BackgroundGOs[i].Count; j++) {
        BackgroundGOs[i][j].transform.position -= new Vector3(Speed, 0.0f, 0.0f) * Time.deltaTime;
        if (BackgroundGOs[i][j].transform.position.x > CamXbase + ObjXsize) {
          BackgroundGOs[i][j].transform.position -= new Vector3(ObjXsize * 2, 0.0f, 0.0f);
        } else if (BackgroundGOs[i][j].transform.position.x < CamXbase - ObjXsize) {
          BackgroundGOs[i][j].transform.position += new Vector3(ObjXsize * 2, 0.0f, 0.0f);
        }
        if (BackgroundGOs[i][j].transform.position.y > CamYbase + ObjYsize) {
          BackgroundGOs[i][j].transform.position -= new Vector3(0.0f, ObjYsize * 2, 0.0f);
        } else if (BackgroundGOs[i][j].transform.position.y < CamYbase - ObjYsize) {
          BackgroundGOs[i][j].transform.position += new Vector3(0.0f, ObjYsize * 2, 0.0f);
        }
      }
    }
  }
}

