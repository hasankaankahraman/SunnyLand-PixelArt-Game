using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ezicikutuscript : MonoBehaviour
{


    [SerializeField]
    GameObject yokolmaefekt;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Frog"))
        {
            collision.transform.parent.gameObject.SetActive(false);
            Instantiate(yokolmaefekt, transform.position, transform.rotation);


            SesController.instance.Sesefektcikar(0);
        }
    }
}
