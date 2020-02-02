using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class character : MonoBehaviour
{
    public Animator anim;
    public float vel = 3f;
    public Transform viraH;
    public bool face = true;
    private bool vivo;
    public Image img;
    public GameObject entrada;
    public bool SuperVel;
    public int p;
    public float jumpheight;
    public int DoubleJumpForce = 2;
    public int JumpingKey = 0;

    public GameObject nuvem;
    public GameObject itemPerna;

    private bool isjumping = false;
    private Rigidbody2D rd2d;
    private bool grounded;

    //public AudioSource SomAndar;
    //public AudioSource SomCorrer;

    // Use this for initialization
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        viraH = GetComponent<Transform>();
        vivo = true;
        SuperVel = false;
        //SomAndar.Stop();
        //SomCorrer.Stop();


    }

    // Update is called once per frame
    void Update()
    {

        if (vivo == true)
        {
            if (Input.GetKey(KeyCode.RightArrow) && !face)
            {
                flip();
            }

            if (Input.GetKey(KeyCode.LeftArrow) && face)
            {
                flip();
            }
        }

        if (SuperVel)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                vel = 6;
                //SomCorrer.Play();
            }
            else
            {
                vel = 3;
                //SomCorrer.Stop();
            }
        }



        if (vivo == true)
        {
            //    if (p == 1)
            //    {
            //        anim.SetBool("paradoCima", true);
            //        anim.SetBool("HParado", false);
            //        anim.SetBool("MoveEsquerda", false);
            //        anim.SetBool("MoveCima", false);
            //        anim.SetBool("MoveBaixo", false);
            //    }
            //    else if (p == 2)
            //    {
            //        anim.SetBool("HParado", true);
            //        anim.SetBool("paradoCima", false);
            //        anim.SetBool("MoveEsquerda", false);
            //        anim.SetBool("MoveCima", false);
            //        anim.SetBool("MoveBaixo", false);
            //    }
            //    else if (p == 3 || p == 4)
            //    {
            //        anim.SetBool("HParado", false);
            //        anim.SetBool("paradoCima", false);
            //        anim.SetBool("MoveEsquerda", false);
            //        anim.SetBool("ladoParado", true);
            //        anim.SetBool("MoveCima", false);
            //        anim.SetBool("MoveBaixo", false);
            //    }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //anim.SetBool("paradoCima", false);
                //anim.SetBool("HParado", false);
                //anim.SetBool("MoveEsquerda", true);
                //anim.SetBool("ladoParado", false);
                //anim.SetBool("MoveCima", false);
                //anim.SetBool("MoveBaixo", false);
                transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
                p = 4;

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                //anim.SetBool("paradoCima", false);
                //anim.SetBool("HParado", false);
                //anim.SetBool("MoveEsquerda", true);
                //anim.SetBool("ladoParado", false);
                //anim.SetBool("MoveCima", false);
                //anim.SetBool("MoveBaixo", false);
                transform.Translate(new Vector2(vel * Time.deltaTime, 0));
                p = 3;

            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                //anim.SetBool("paradoCima", false);
                //anim.SetBool("HParado", false);
                //anim.SetBool("MoveEsquerda", false);
                //anim.SetBool("ladoParado", false);
                //anim.SetBool("MoveCima", false);
                //anim.SetBool("MoveBaixo", true);
                p = 2;
                //transform.Translate(new Vector2(0, -vel * Time.deltaTime));

            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                VerifyPlayerJump();
                //anim.SetBool("paradoCima", false);
                //anim.SetBool("HParado", false);
                //anim.SetBool("MoveEsquerda", false);
                //anim.SetBool("ladoParado", false);
                //anim.SetBool("MoveCima", true);
                //anim.SetBool("MoveBaixo", false);
            }


            this.transform.localRotation = Quaternion.Euler(0, 0, 0);

        }




        //    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        //    {
        //        SomAndar.Play();
        //    }
        //    else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        //    {
        //        SomAndar.Stop();
        //    }


    }

    private void VerifyPlayerJump()
    {
        if (JumpingKey == 0)
        {
            p = 1;
            JumpingKey++;
            grounded = false;
            rd2d.AddForce(Vector2.up * jumpheight);
            isjumping = true;
            VerifyPlayerJump();
           // Debug.Log("to pulando");
        }

        if (JumpingKey >= 1 && JumpingKey < 3)
        {
            rd2d.AddForce(Vector2.up * jumpheight * DoubleJumpForce);
            grounded = false;
            isjumping = true;
            //Debug.Log("double jumping");
            JumpingKey--;
        }
        else
            grounded = true;
        
    }

    void flip()
    {
        face = !face;
        Vector3 scala = viraH.localScale;
        scala.x *= -1;
        viraH.localScale = scala;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("OBJ"))
        {
            isjumping = false;
            //Debug.Log(isjumping);
        }

    }

    public void OnCollisionExit2D(Collision2D other)
    {
        //if (other.gameObject.CompareTag("OBJ"))
        //{
        //    vel = 3f;
        //}
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("item"))
        {
            GameObject clone;
            clone = Instantiate(nuvem, transform.position, transform.rotation);
            Destroy(itemPerna, 1f);
        }

        if (img.fillAmount == 0)
        {
            vivo = false;
        }


    }

   
}




        

        








