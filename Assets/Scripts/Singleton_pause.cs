using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton_pause : MonoBehaviour
{ 
    public static Singleton_pause instance;	
  	void Awake()
    {
        if(instance == null) instance = this;
        else                 Destroy (gameObject);
		DontDestroyOnLoad(gameObject);
    }
}
