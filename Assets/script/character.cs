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

    public GameObject nuvem;
    public GameObject itemPerna;
    public bool cabeca = true;
    public bool perna = false;

    //private bool isjumping = false;
    private Rigidbody2D rd2d;
    private bool grounded = true;
    public int JumpCount = 0;
    public float jumpForce = 12f;
    private Rigidbody2D rigid;
    private bool candoublejump;

    //public AudioSource SomAndar;
    //public AudioSource SomCorrer;

    // Use this for initialization
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        viraH = GetComponent<Transform>();
        vivo = true;
        SuperVel = false;
        cabeca = true;
        perna = false;

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

            if (cabeca == true)
            {
                if (Input.GetKey(KeyCode.LeftArrow) && cabeca == true)
                {
                    anim.SetBool("rodaAnda", true);
                    anim.SetBool("rodaParada", false);
                    anim.SetBool("rodaPula", false);
                    //anim.SetBool("ladoParado", false);
                    //anim.SetBool("MoveCima", false);
                    //anim.SetBool("MoveBaixo", false);
                    transform.Translate(new Vector2(-vel * Time.deltaTime, 0));


                }
                else if (Input.GetKey(KeyCode.RightArrow) && cabeca == true)
                {
                    anim.SetBool("rodaAnda", true);
                    anim.SetBool("rodaParada", false);
                    anim.SetBool("rodaPula", false);
                    transform.Translate(new Vector2(vel * Time.deltaTime, 0));

                }
                else if (Input.GetKey(KeyCode.UpArrow) && cabeca == true)
                {
                    VerifyPlayerJump();
                    anim.SetBool("rodaAnda", false);
                    anim.SetBool("rodaParada", false);
                    anim.SetBool("rodaPula", true);

                }
                else if (cabeca == true)
                {
                    anim.SetBool("rodaAnda", false);
                    anim.SetBool("rodaParada", true);
                    anim.SetBool("rodaPula", false);

                }

            }

            if (perna)
            {
                anim.SetBool("rodaAnda", false);
                anim.SetBool("rodaParada", true);
                anim.SetBool("rodaPula", false);

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    Debug.Log("oioi");
                    anim.SetBool("rodaAnda", false);
                    anim.SetBool("rodaParada", false);
                    anim.SetBool("rodaPula", false);
                    anim.SetBool("pernaAndando", true);
                    anim.SetBool("pernaParado", false);
                    anim.SetBool("pernaPulo", false);
                    //anim.SetBool("ladoParado", false);
                    //anim.SetBool("MoveCima", false);
                    //anim.SetBool("MoveBaixo", false);
                    transform.Translate(new Vector2(-vel * Time.deltaTime, 0));


                }
                else if (Input.GetKey(KeyCode.RightArrow) && perna == true)
                {
                    anim.SetBool("rodaAnda", false);
                    anim.SetBool("rodaParada", false);
                    anim.SetBool("rodaPula", false);

                    anim.SetBool("pernaAndando", true);
                    anim.SetBool("pernaParado", false);
                    anim.SetBool("pernaPulo", false);

                    transform.Translate(new Vector2(vel * Time.deltaTime, 0));

                }
                else if (Input.GetKey(KeyCode.UpArrow) && perna == true)
                {
                    VerifyPlayerJump();
                    anim.SetBool("rodaAnda", false);
                    anim.SetBool("rodaParada", false);
                    anim.SetBool("rodaPula", false);

                    anim.SetBool("pernaAndando", false);
                    anim.SetBool("pernaParado", false);
                    anim.SetBool("pernaPulo", true);

                }
                else if (perna == true)
                {
                    anim.SetBool("rodaAnda", false);
                    anim.SetBool("rodaParada", false);
                    anim.SetBool("rodaPula", false);

                    anim.SetBool("pernaAndando", false);
                    anim.SetBool("pernaParado", true);
                    anim.SetBool("pernaPulo", false);

                }

                this.transform.localRotation = Quaternion.Euler(0, 0, 0);

            }
        }


        //========================================================================






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

        if (Input.GetKey(KeyCode.UpArrow) && grounded == true && JumpCount == 0)
        {
            Debug.Log("pulo");
            rigid.AddForce(new Vector2(0, jumpForce));
            candoublejump = true;
        }

        void OnCollisionEnter2D(Collision2D collide)
        {

        }

        void flip()
        {
            face = !face;
            Vector3 scala = viraH.localScale;
            scala.x *= -1;
            viraH.localScale = scala;
        }


         void OnCollisionExit2D(Collision2D other)
        {
            //if (other.gameObject.CompareTag("OBJ"))
            //{
            //    vel = 3f;
            //}
        }

         void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("item"))
            {
                GameObject clone;
                clone = Instantiate(nuvem, transform.position, transform.rotation);
                perna = true;
                cabeca = false;
                Destroy(itemPerna);
                Destroy(clone, 3f);

            }
            if (other.gameObject.CompareTag("OBJ"))
            {
                JumpCount = 0;
                grounded = false;

            }

            if (img.fillAmount == 0)
            {
                vivo = false;
            }


        }


    }
}















