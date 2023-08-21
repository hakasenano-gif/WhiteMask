using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CircleCollider2D))]
public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate (0.2f, 0, 0);
    
		if(transform.position.x > 10) 
          {
          Destroy (gameObject);
          }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      Destroy (this);

    }
}
