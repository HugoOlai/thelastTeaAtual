﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropItem : MonoBehaviour
{
    //private Rigidbody2D rd;
    private BoxCollider2D bc;
    public bool bcP;
    // Start is called before the first frame update
    void Start()
    {
        bc = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destroco"))
        {
            bcP = true;
        }        
    }
}
