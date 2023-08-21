using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainingLives : MonoBehaviour {
  public GameObject LivePrefab;

  private GameObject GameManagerGO;
  private GameObject RemainingLivesGO;
  private Vector3 LiveSize = Vector3.zero;
  private List<GameObject> LiveGOs = new List<GameObject>();

  void Start() {
    if (LivePrefab) {
      GameManagerGO = GameObject.Find("Gamemanager");
      RemainingLivesGO = GameObject.Find("RemainingLives");
      LiveSize = new Vector3(LivePrefab.GetComponent<SpriteRenderer>().bounds.size.x, LivePrefab.GetComponent<SpriteRenderer>().bounds.size.y, 0.0f);
    } else {
      Debug.Log("Specify the live prefab.");
    }
  }

  void FixedUpdate() {
    int LiveGOsCount;
    float RemainingLivesXbase, RemainingLivesYbase, LivesXStart;
    if (LivePrefab) {
      LiveGOsCount = LiveGOs.Count;
      RemainingLivesXbase = RemainingLivesGO.transform.position.x;
      RemainingLivesYbase = RemainingLivesGO.transform.position.y;
      if (LiveGOsCount < GameManagerGO.GetComponent<gamemanager>().PC_Life) {
        for (int i = 0; i < GameManagerGO.GetComponent<gamemanager>().PC_Life - LiveGOsCount; i++) {
          LiveGOs.Add(Object.Instantiate(LivePrefab) as GameObject);
        }
      } else {
        for (int i = 1; i <= LiveGOsCount - GameManagerGO.GetComponent<gamemanager>().PC_Life; i++) {
          Destroy(LiveGOs[LiveGOsCount - i]);
          LiveGOs.RemoveAt(LiveGOsCount - i);
        }
      }
      LivesXStart = RemainingLivesXbase - LiveSize.x * (GameManagerGO.GetComponent<gamemanager>().PC_Life_MAX - 1) / 2;
      for (int i = 0; i < LiveGOs.Count; i++) {
        LiveGOs[i].transform.position = new Vector3(LivesXStart + LiveSize.x * i, RemainingLivesYbase, LiveGOs[i].transform.position.z);
      }
    }
  }
}

