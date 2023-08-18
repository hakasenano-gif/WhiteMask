using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton_printNowScore : MonoBehaviour
{ 
    public static Singleton_printNowScore instance;	
  	void Awake()
    {
        if(instance == null) instance = this;
        else                 Destroy (gameObject);
		DontDestroyOnLoad(gameObject);
    }
}
