using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class printNowScore : MonoBehaviour
{

    public TextMeshProUGUI printText;
    public GameObject Gamemanager_obj;
	private gamemanager Gamemanager;

    public int score;

    void Awake()
    {
        Gamemanager_obj = GameObject.Find("Gamemanager");
        Gamemanager = Gamemanager_obj.GetComponent<gamemanager>();
    }

    void FixedUpdate()
    {
        if(Gamemanager != null)
        {
            score = Gamemanager.Score;
            printText.text = "<SIZE=30>SCORE:" + score.ToString();
        }
    }



}
