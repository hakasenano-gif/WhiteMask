using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintSlashGauge : MonoBehaviour
{
    public Slider gaugeSlider;
    public GameObject Player_obj;
    public player_controller Player_controller;
    // Start is called before the first frame update
    void Awake()
    {
        gaugeSlider = GetComponent<Slider>();
    }
    void Start()
    {

        Player_obj = GameObject.Find("Player");
        if(Player_obj != null)
        {
        Player_controller = Player_obj.GetComponent<player_controller>();
        gaugeSlider.maxValue = Player_controller.slash_cooldownmax;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Player_controller != null) gaugeSlider.value = Player_controller.slash_cooldownmax - Player_controller.slash_cooldown;
        else
        {
            Player_obj = GameObject.Find("Player");
            if(Player_obj !=null)
            {
                Player_controller = Player_obj.GetComponent<player_controller>();
                gaugeSlider.maxValue = Player_controller.slash_cooldownmax;
            }
        }
    }


}
