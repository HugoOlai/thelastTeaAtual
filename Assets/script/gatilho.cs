using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatilho : MonoBehaviour
{
    public Rigidbody2D rd2d;
    public bool ativaTrigger;
    // Start is called before the first frame update
    void Start()
    {
        //bc = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("heroi"))
        {
            ativaTrigger = true;
            rd2d.simulated = true;
        }


    }
}
