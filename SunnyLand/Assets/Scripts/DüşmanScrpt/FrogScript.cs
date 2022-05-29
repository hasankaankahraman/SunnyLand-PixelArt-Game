using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    public float harekethizi;
    public Transform solhedef, saghedef;

    bool sagtaraf;

    Rigidbody2D rb;

    public SpriteRenderer sr;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    private void Start()
    {
        solhedef.parent = null;
        saghedef.parent = null;


        sagtaraf = true;
    }

    private void Update()
    {
        if (sagtaraf)
        {
            rb.velocity = new Vector2(harekethizi, rb.velocity.y);

            sr.flipX = true;

            if (transform.position.x > saghedef.position.x)
            {
                sagtaraf = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-harekethizi, rb.velocity.y);
            sr.flipX = false; // Kurbaðanýn saða sola giderken yönünü deðiþtirdik

            if (transform.position.x < solhedef.position.x)
            {
                sagtaraf = true;
            }
        }
    }
}
