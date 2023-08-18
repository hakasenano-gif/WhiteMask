using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton_printLimitTime : MonoBehaviour
{ 
    public static Singleton_printLimitTime instance;	
  	void Awake()
    {
        if(instance == null) instance = this;
        else                 Destroy (gameObject);
		DontDestroyOnLoad(gameObject);
    }
}
