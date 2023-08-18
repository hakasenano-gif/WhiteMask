using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour {
  public float Scale = 1.0f;
  public float Interval = 1.0f;
  public List<Sprite> Images = new List<Sprite>();

  private int ImageID = 0;
  private float PassedTime = 0.0f;

  void Start() {
    if (Images.Count == 0) {
      Debug.Log("Specify Image(s).");
      Destroy(gameObject);
    } else {
      gameObject.transform.localScale = Vector3.one * Scale;
      gameObject.GetComponent<SpriteRenderer>().sprite = Images[0];
    }
  }

  void FixedUpdate() {
    PassedTime += Time.deltaTime;
    if (PassedTime >= Interval) {
      PassedTime -= Interval;
      ImageID = (ImageID + 1) % Images.Count;
      gameObject.GetComponent<SpriteRenderer>().sprite = Images[ImageID];
    }
  }
}

