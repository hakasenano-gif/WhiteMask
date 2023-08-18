using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class printLimitTime_Text : MonoBehaviour
{

    public TextMeshProUGUI printTime;
    public GameObject Gamemanager_obj;
	private gamemanager Gamemanager;


    void Awake()
    {
        Gamemanager_obj = GameObject.Find("Gamemanager");
        Gamemanager = Gamemanager_obj.GetComponent<gamemanager>();
    }

    void FixedUpdate()
    {
        if(Gamemanager != null)
        {
            printTime.text = "<SIZE=50>Time:" + Mathf.CeilToInt(Gamemanager.stage_time).ToString();
        }
    }



}
