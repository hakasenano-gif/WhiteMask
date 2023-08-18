using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_death_effect : MonoBehaviour
{
    private SpriteRenderer sprite;
    public AudioClip se_death;
    AudioSource audioSource;
    private float time_to_delete = 2f;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(se_death);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sprite.color -= new Color (0,0,0,3*Time.deltaTime);

        time_to_delete-=Time.deltaTime;
        if(time_to_delete <=0) Destroy(gameObject);
        
    }
}
