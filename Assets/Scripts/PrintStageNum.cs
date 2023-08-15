using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PrintStageNum : MonoBehaviour
{

    public TextMeshProUGUI printText;
	private float transparent = 1;

    void Start()
    {
		if(SceneManager.GetActiveScene().name == "MainScene1")
		{
        printText.text = "Stage 1".ToString();
		}

		if(SceneManager.GetActiveScene().name == "MainScene2")
		{
        printText.text = "Stage 2".ToString();
		}

		if(SceneManager.GetActiveScene().name == "MainScene3")
		{
        printText.text = "Stage 3".ToString();
		}

		if(SceneManager.GetActiveScene().name == "BossScene1")
		{
        printText.text = "ボス：ドラゴン".ToString();
		}

		if(SceneManager.GetActiveScene().name == "BossScene2")
		{
        printText.text = "ボス：魔王".ToString();
		}

		if(SceneManager.GetActiveScene().name == "BossScene3")
		{
        printText.text = "ボス：you".ToString();
		}
    }
    void Update()
    {
        printText.alpha = transparent;
		transparent -= Time.deltaTime * 0.5f;

		if(transparent < 0) Destroy(gameObject);
    }

}
