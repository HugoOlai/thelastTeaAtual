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

    public float jumpForce;
    
    public GameObject nuvem;
    public GameObject chaoDePulo;
    public GameObject itemPerna;
    private GameObject clone;
    private GameObject clonechao;
    public Rigidbody2D pedra;

    public bool cabeca = true;
    public bool perna = false;
    public bool itensFoiDestruido = false;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float jumpTimeCounter;
    public float JumpTime;
    private bool isJumping;

    //private bool isjumping = false;
    private Rigidbody2D rd2d;
    private bool ColidindoComChao = false;
    private Rigidbody2D rigid;
    private bool candoublejump;
    private int pulos = 0;

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
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
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

        if (!itensFoiDestruido)
        {
            vel = 3f;
            if (SuperVel)
            {
                if (Input.GetKey(KeyCode.Q))
                {                    
                    vel = 6f;
                    //SomCorrer.Play();
                }
                else
                {
                    vel = 3f;
                    //omCorrer.Stop();
                }
            }
        }
        else
        {
            vel = 0f;
            if (clone == null)
            {               
                itensFoiDestruido = false;
            }
        }

        if (vivo == true)
        {
            
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
                }else if (Input.GetKey(KeyCode.RightArrow) && cabeca == true)
                {
                    anim.SetBool("rodaAnda", true);
                    anim.SetBool("rodaParada", false);
                    anim.SetBool("rodaPula", false);
                    transform.Translate(new Vector2(vel * Time.deltaTime, 0));

                }else if (Input.GetKey(KeyCode.UpArrow) && cabeca == true)
                {
                    VerifyPlayerJump();
                    anim.SetBool("rodaAnda", false);
                    anim.SetBool("rodaParada", false);
                    anim.SetBool("rodaPula", true);

                }else if (cabeca == true)
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
                else if (isGrounded == true && Input.GetKey(KeyCode.UpArrow) && perna == true)
                {
                    isJumping = true;
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

                    
                    //if (Input.GetKeyUp(KeyCode.UpArrow) && pulos < 2)
                    //{
                    //    clonechao = Instantiate(chaoDePulo, new Vector2(transform.position.x, transform.position.y - 0.1f), transform.rotation);
                    //    Destroy(clonechao, 0.3f);                        
                    //}

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
            if (ColidindoComChao)
            {
                rigid.velocity = Vector2.up * jumpForce;            
                
                if (Input.GetKey(KeyCode.UpArrow) && isJumping == true)
                {
                    if (jumpTimeCounter > 0)
                    {
                        ColidindoComChao = false;
                        rigid.velocity = Vector2.up * jumpForce;
                        jumpTimeCounter -= Time.deltaTime;
                }
                else{
                    isJumping = false;
                }

                }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                isJumping = false;
            }

                ColidindoComChao = false;
                 
            }           
        }

        void OnCollisionEnter2D(Collision2D collide)
        {
            if (collide.gameObject.CompareTag("chao"))
            {                
                ColidindoComChao = true;
                            
            }
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
            //if (other.gameObject.CompareTag("item"))
            //{
                
            //}
        }

    

    void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("item"))
            {                
                clone = Instantiate(nuvem, transform.position, transform.rotation);
                perna = true;
                cabeca = false;
                Destroy(itemPerna);
                Destroy(clone, 3f);
                itensFoiDestruido = true;
                vel = 0f;
                SuperVel = true;
                
            }     

            if (other.gameObject.CompareTag("pedra"))
            {
                pedra.AddForce(Vector2.right * 200);
            }

            if (img.fillAmount == 0)
            {
                vivo = false;
            }
    }

    

}
















