using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class life : MonoBehaviour
{
    public Image img;
    public Image img1;
    public Image img2;
    public GameObject fantasma;
    public bool ataque = false;
    public Renderer semeTextofinal;
    public Renderer textodePerda;
    public Renderer textofinal;
    public float trans = 0.01f;
    public bool inimigoMorreu = false;
    public float tempo;

    void Start()
    {
        //semeTextofinal.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        //textofinal.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        //textodePerda.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }
    // Use this for initialization
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            ataque = false;
        }

        if (ataque)
        {
            if (img2.fillAmount > 0)
            {
                img2.fillAmount -= 0.25f;
            }
            else if (img1.fillAmount > 0)
            {
                img1.fillAmount -= 0.25f;
            }
            else if (img.fillAmount > 0)
            {
                img.fillAmount -= 0.25f;
            }
            else
            {
                //textodePerda.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, trans += Time.deltaTime);
                if (tempo > 20)
                    //Application.LoadLevel("01 - Hugo");
                    Debug.Log("carreguei cena");
            }
        }
        if (inimigoMorreu)
        {
            semeTextofinal.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, trans += Time.deltaTime);
            tempo += Time.deltaTime;
            if (tempo > 8)
            {
                //textofinal.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, trans += Time.deltaTime);
                if (tempo > 20)
                    //Application.LoadLevel("01 - Hugo");
                    Debug.Log("carreguei cena");
            }

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            ataque = true;
        }
        if (collision.gameObject.CompareTag("inimigo") && Input.GetKey(KeyCode.Q))
        {
            Destroy(fantasma.gameObject, 0.1f);
            inimigoMorreu = true;
        }

    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            ataque = false;
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            ataque = true;
        }


    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            ataque = false;
        }
    }

}
