using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintLimitTime_Slider : MonoBehaviour
{
    public Slider LimitTimeSlider;
    public GameObject Gamemanager_obj;
	private gamemanager Gamemanager;
    void Awake()
    {

        Gamemanager_obj = GameObject.Find("Gamemanager");
        Gamemanager = Gamemanager_obj.GetComponent<gamemanager>();
        LimitTimeSlider = GetComponent<Slider>();
    }
    void Start()
    {        
        LimitTimeSlider.maxValue = Gamemanager.stage_time_max;   
    }

    // Update is called once per frame
    void Update()
    {
        LimitTimeSlider.value = Gamemanager.stage_time;
    }
}
