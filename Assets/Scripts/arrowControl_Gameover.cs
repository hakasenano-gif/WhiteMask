using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class arrowControl_Gameover : MonoBehaviour
{
    public RectTransform rect;
    public int choiceNum=0;
    public GameObject Gamemanager;
    void Start()
    {
        rect = GetComponent < RectTransform > ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.DownArrow))
        {
            if(choiceNum == 0) 
            {
                rect.localPosition -= new Vector3(0,30,0);
                choiceNum=1;
            }
        }
        if (Input.GetKeyDown (KeyCode.UpArrow))
        {
            if(choiceNum == 1) 
            {
                rect.localPosition += new Vector3(0,30,0);
                choiceNum=0;
            }
        }

        if((Input.GetKeyDown (KeyCode.Z))||Input.GetKeyDown(KeyCode.Return))
        {
            switch(choiceNum)
            {
                case 0:
                    Gamemanager.SendMessage("Retry");
                    break;
                case 1:
                    Gamemanager.SendMessage("GoToTitle");
                    break;
            }

        }
    }
    private void OnEnable()
    {      
      rect.localPosition += new Vector3(0,30*(choiceNum),0);
      choiceNum = 0;  
    }
}
