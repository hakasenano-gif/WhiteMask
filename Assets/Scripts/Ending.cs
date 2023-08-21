using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject EndingMessage;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        if(EndingMessage == null) Destroy(gameObject);
    }
}
