using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]

    float hareket_hizi;

    [SerializeField]
    float ziplamagucu;

    bool yerdemi;
    public Transform zeminkontrolnoktasi;
    public LayerMask zeminlayer;
    bool ikikezzipla;
    public float geritepmesuresi, geritepmegucu;
    float geritepmesayaci;

    bool yonsagmi;

    Rigidbody2D rb;

    Animator anim;

    public bool hareketetsinmi;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        hareketetsinmi = true;
    }
    private void Update()
    {
        if (hareketetsinmi)
        {
            anim.SetFloat("hareketkizi", Mathf.Abs(rb.velocity.x)); // Karakter sola gittiðinde hareketkizi - deðer alýyor ve anim çalýþmýyor.
            anim.SetBool("yerdemi", yerdemi);                        // Bu yüzden Mathf.Abs fonk kullandýk deðeri mutlak deðer tutuyor.

            if (geritepmesayaci <= 0)
            {
                HareketEttir();
                Zipla();
                Yondegistir();
            }
            else
            {
                geritepmesayaci -= Time.deltaTime;

                if (yonsagmi)
                {
                    rb.velocity = new Vector2(rb.velocity.x, +geritepmegucu);
                }
                else
                {
                    rb.velocity = new Vector2(rb.velocity.x, +geritepmegucu);
                }
            }

        }
        else
        {
            rb.velocity = Vector2.zero;
            anim.SetFloat("hareketkizi", Mathf.Abs(rb.velocity.x));
        }

        if (geritepmesayaci <= 0)
        {
            HareketEttir();
            Zipla();
            Yondegistir();
        }
        else
        {
            geritepmesayaci -= Time.deltaTime;

            if (yonsagmi)
            {
                rb.velocity = new Vector2(rb.velocity.x, +geritepmegucu);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, +geritepmegucu);
            }
        }
        

    }
    void HareketEttir()
    {
        float h = Input.GetAxis("Horizontal");
        float hiz = h * hareket_hizi;

        rb.velocity = new Vector2(hiz, rb.velocity.y);
    }

    void Zipla()
    {
        yerdemi = Physics2D.OverlapCircle(zeminkontrolnoktasi.position, .2f, zeminlayer);
        

        if (yerdemi)
        {
            ikikezzipla = true;
        }
        if (Input.GetButtonDown("Jump"))
        {
            SesController.instance.Sesefektcikar(7);
            if (yerdemi)
            {
                rb.velocity = new Vector2(rb.velocity.x, ziplamagucu);
            }
            else
            {
                if(ikikezzipla)
                rb.velocity = new Vector2(rb.velocity.x, ziplamagucu);
                
                ikikezzipla = false;
                
            }
            
        }
        
    }

    void Yondegistir()
    {
        Vector2 geciciScale = transform.localScale;

        if (rb.velocity.x > 0)
        {
            yonsagmi = true;
            geciciScale.x = 1f;
        }else if (rb.velocity.x < 0)
        {
            yonsagmi = false;
            geciciScale.x = -1f;
        }
        transform.localScale = geciciScale;
    }

    public void GeritepmeFNC()
    {
        geritepmesayaci = geritepmesuresi;
        rb.velocity = new Vector2(0, rb.velocity.y);
        anim.SetTrigger("damage"); // hasar animasyonunu karakter hasar aldýðýnda çalýþtýrdýk.
    }
}
