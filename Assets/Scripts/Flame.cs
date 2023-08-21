using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public float lifetime = 3.0f; // オブジェクトの寿命（秒）

    // Start is called before the first frame update
    void Start()
    {
        // lifetime秒後にオブジェクトを削除
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
