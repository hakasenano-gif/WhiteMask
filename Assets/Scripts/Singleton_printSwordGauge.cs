using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton_printSwordGauge : MonoBehaviour
{ 
    public static Singleton_printSwordGauge instance;	
  	void Awake()
    {
        if(instance == null) instance = this;
        else                 Destroy (gameObject);
		DontDestroyOnLoad(gameObject);
    }
}
