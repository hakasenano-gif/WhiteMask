using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class flashText : MonoBehaviour
{
    public float transparent = 0.3f;
    public float flashSpeed = 0.002f;
    private bool Is_gettingBrighter = false;
    public TextMeshProUGUI Text;

    // Update is called once per frame
    void FixedUpdate()
    {
        Text.alpha = transparent;
        if(transparent >= 0.3) Is_gettingBrighter = false;
        else if(transparent <= 0) Is_gettingBrighter = true;
        if(Is_gettingBrighter == true) transparent += flashSpeed;
        else transparent -= flashSpeed;
    }
}
