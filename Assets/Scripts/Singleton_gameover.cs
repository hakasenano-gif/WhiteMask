using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton_gameover : MonoBehaviour
{ 
    public static Singleton_gameover instance;	
  	void Awake()
    {
        if(instance == null) instance = this;
        else                 Destroy (gameObject);
		DontDestroyOnLoad(gameObject);
    }
}
