using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{



    public int maxsaglik, gecerlisaglik;

    [SerializeField]
    GameObject yokolmaefekt;

    UIController uiController;
    public float yenilmezliksuresi;
    float yenilmezliksayaci;

    SpriteRenderer spriterenderer;

    PlayerController playerController;

    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
        spriterenderer = GetComponent<SpriteRenderer>();// Player dikene geldiðinde alpha olayý. Spriterender komponentine ulaþtýk.
        uiController = Object.FindObjectOfType<UIController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        gecerlisaglik = maxsaglik;
    }

    public void HasarAl()
    {
        if (yenilmezliksayaci <= 0)
        {
            gecerlisaglik--;
            if (gecerlisaglik <= 0)
            {
                gecerlisaglik = 0;
                gameObject.SetActive(false);
                Instantiate(yokolmaefekt, transform.position, transform.rotation);
                SesController.instance.Sesefektcikar(4);


            }
            else
            {
                yenilmezliksayaci = yenilmezliksuresi;
                spriterenderer.color = new Color(spriterenderer.color.r,spriterenderer.color.g,spriterenderer.color.b,0.5f);

                playerController.GeritepmeFNC();
            }
            uiController.Saglikdurumunuguncelle();
        }

    }
        
    // Update is called once per frame
    void Update()
    {
        yenilmezliksayaci -= Time.deltaTime;
        if (yenilmezliksayaci <= 0)
        {
            spriterenderer.color = new Color(spriterenderer.color.r, spriterenderer.color.g, spriterenderer.color.b, 1f);
        }
    }
    public void CanartirFNC()
    {
        gecerlisaglik++;
        if (gecerlisaglik >= maxsaglik)
        {
            gecerlisaglik = maxsaglik;
        }
        uiController.Saglikdurumunuguncelle();
    }
}
