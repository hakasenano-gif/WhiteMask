using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrintGameResult : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI PrintMessage;
    public GameObject Gamemanager_obj;
    private gamemanager Gamemanager;


    void Awake()
    {
        Gamemanager_obj = GameObject.Find("Gamemanager");
        Gamemanager = Gamemanager_obj.GetComponent<gamemanager>();
    }
    void Start()
    {
        score = Gamemanager.Score;
        PrintMessage.text =
        "<align=center><SIZE=70>Congratulations!!\n"
        +"<SIZE=50>Final SCORE:" + score + "\n"
        +"<SIZE=30>PRESS Z TO RETURN TITLE ".ToString();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)) Gamemanager_obj.SendMessage("GoToTitle");
    }
}
