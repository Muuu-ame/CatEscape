using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using JetBrains.Annotations;
using UnityEngine;

public class LButtonslide : MonoBehaviour
{
    public Rigidbody2D Rb { get; private set; }
    public float jumpPower;
    private　Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
    　　
       Application.targetFrameRate = 60;
       rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow));
        {
            transform.Translate(-3,0,0);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow));
        {
            transform.Translate(3,0,0);
        }
    }
}
