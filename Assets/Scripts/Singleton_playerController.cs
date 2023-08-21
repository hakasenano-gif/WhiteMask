using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton_playerController : MonoBehaviour
{ 
    public static Singleton_playerController instance;	
  	void Awake()
    {
        if(instance == null) instance = this;
        else                 Destroy (gameObject);
		DontDestroyOnLoad(gameObject);
    }
}
