using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob_ghostParent : MonoBehaviour
{
    public GameObject child1;
    public GameObject child2;
    public GameObject child3;
    public GameObject child4;
    
    [SerializeField]private int dirNum;
    [SerializeField]private float timeToStartDirChange = 0.3f;
    void Start()
    {
        StartCoroutine("initialize");   
    }

    // Update is called once per frame
    void Update()
    {
        if((child1==null)&&(child2==null)&&(child3==null)&&(child4==null)) Destroy(gameObject);
        
    }

    IEnumerator initialize()
    {
        var interval = new WaitForSeconds(0.1f); 
        child1.SetActive(true);
        yield return new WaitForSeconds(0.075f);
        child2.SetActive(true);
        yield return interval;
        child3.SetActive(true);
        yield return interval;
        child4.SetActive(true);
        yield return new WaitForSeconds(timeToStartDirChange);
        StartCoroutine("changedir");
    }

    IEnumerator changedir()
    {
        var interval = new WaitForSeconds(0.1f); 
        while(true)
        {
            
            dirNum = Random.Range(-1,2) - dirNum;

            if(child1!=null) child1.transform.Rotate(0,0,30*(dirNum));
            yield return interval;
            if(child2!=null)child2.transform.Rotate(0,0,30*(dirNum));
            yield return interval;
            if(child3!=null)child3.transform.Rotate(0,0,30*(dirNum));
            yield return interval;
            if(child4!=null)child4.transform.Rotate(0,0,30*(dirNum));

            yield return new WaitForSeconds(timeToStartDirChange);        
        }
    }
}
