using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasarController : MonoBehaviour
{
    HealthController healthController;

    private void Awake()
    {
        healthController = Object.FindObjectOfType<HealthController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            healthController.HasarAl();
            SesController.instance.Sesefektcikar(3);
        }
    }
}
