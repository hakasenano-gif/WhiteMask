using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_death_effect : MonoBehaviour
{
    private float time_to_delete = 0.367f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time_to_delete-=Time.deltaTime;
        if(time_to_delete <=0) Destroy(gameObject);
    }
}
