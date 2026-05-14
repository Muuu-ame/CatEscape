using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomarrow : MonoBehaviour
{
    private float time;
    private float vecX;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
    }

    void Update() 
    {
       time -= Time.deltaTime;

       if (time <= 0.0f)
       {
            time = 1.0f;
            vecX = Random.Range(-4.5f,4.5f);
            transform.Translate(vecX,2,0);
       } 
    }
    
}
