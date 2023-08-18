using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class printGAMEOVER : MonoBehaviour
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

    void Start()
    {

    }

    private void OnEnable()
    {      
        if(Gamemanager != null)
        {
            score = Gamemanager.Score;
        }

        printText.text = "<SIZE=45>GAMEOVER\n\n<SIZE=25>SCORE:" + score + "\n\n\n再挑戦する\nタイトルに戻る".ToString();
    }

}
