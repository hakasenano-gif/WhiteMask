using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Change_Scene : MonoBehaviour
{
    public string targetSceneName; // 遷移先のシーン名
    public KeyCode triggerKey = KeyCode.A; // トリガーとなるキーコード
    public GameObject GameManager;

    private void Start()
    {
        GameManager = GameObject.Find("Gamemanager");
    }
    public void BtnOnClick()
    {
        GameManager.SendMessage("TitleToGame","targetSceneName");
    }

    private void Update()
    {
        if(GameManager == null) GameManager = GameObject.Find("Gamemanager");
        if (Input.GetKeyDown(triggerKey))
        {
            GameManager.SendMessage("TitleToGame",targetSceneName);
        }
    }
}
