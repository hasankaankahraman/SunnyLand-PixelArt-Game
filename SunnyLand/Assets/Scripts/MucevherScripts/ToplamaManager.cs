using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToplamaManager : MonoBehaviour
{

    [SerializeField]
    bool elmasmi,kirazmi;

    [SerializeField]
    GameObject toplamaefekt;


    bool toplandimi;

    LevelManager levelmanager;
    UIController uIController;
    HealthController healthController;
    private void Awake()
    {
        levelmanager = Object.FindObjectOfType<LevelManager>();
        uIController = Object.FindObjectOfType<UIController>();
        healthController = Object.FindObjectOfType<HealthController>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !toplandimi)
        {
            if (elmasmi)
            {
                levelmanager.toplananelmassayisi++;

                toplandimi = true;
                Destroy(gameObject);

                uIController.Elmassayisinigüncelle();

                Instantiate(toplamaefekt, transform.position, transform.rotation);
                SesController.instance.Karisiksesefektcikar(2);
            }
            if (kirazmi)
            {
                if (healthController.gecerlisaglik != healthController.maxsaglik)
                {
                    
                    toplandimi = true;
                    Destroy(gameObject);
                    healthController.CanartirFNC();

                    Instantiate(toplamaefekt, transform.position, transform.rotation);
                    SesController.instance.Sesefektcikar(9);
                }
            }
            
        }
    }
}
