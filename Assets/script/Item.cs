using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : dropItem
{
    private Rigidbody2D rd2d;
    public float jumpheight;
    private bool isjumping;
    public bool drop;
    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        isjumping = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(bcP == true)
        Drop(bcP);
    }

    public void Drop(bool e)
    {
       
           
            if (isjumping)
            {
                rd2d.AddForce(Vector2.up * jumpheight);
                rd2d.AddForce(Vector2.right * jumpheight);
                isjumping = false;
        }
        else
        {
            Debug.Log(e);
        }

    }

}

