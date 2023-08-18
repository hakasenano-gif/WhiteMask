using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Change_Scene : MonoBehaviour
{
    public string targetSceneName; // 遷移先のシーン名
    public KeyCode triggerKey = KeyCode.A; // トリガーとなるキーコード

    public void BtnOnClick()
    {
        SceneManager.LoadScene(targetSceneName);
    }

    private void Update()
    {
        if (Input.GetKeyDown(triggerKey))
        {
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
