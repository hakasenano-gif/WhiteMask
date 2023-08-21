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
        printText.text = "<align=center>Stage 1".ToString();
		}

		else if(SceneManager.GetActiveScene().name == "MainScene2")
		{
        printText.text = "<align=center>Stage 2".ToString();
		}

		else if(SceneManager.GetActiveScene().name == "MainScene3")
		{
        printText.text = "<align=center>Stage 3".ToString();
		}

		else if(SceneManager.GetActiveScene().name == "BossScene1")
		{
        printText.text = "<align=center>ボス：悪魔".ToString();
		}

		else if(SceneManager.GetActiveScene().name == "BossScene2")
		{
        printText.text = "<align=center>ボス：魔王".ToString();
		}

		else if(SceneManager.GetActiveScene().name == "BossScene3")
		{
        printText.text = "<align=center>ボス：ドラゴン".ToString();
		}
		else printText.text = "".ToString();
    }
    void Update()
    {
        printText.alpha = transparent;
		transparent -= Time.deltaTime * 0.5f;

		if(transparent < 0) Destroy(gameObject);
    }

}
