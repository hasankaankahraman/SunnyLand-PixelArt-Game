using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesController : MonoBehaviour
{
    public static SesController instance;



    public AudioSource[] sesefektleri;
    private void Awake()
    {
        instance = this;
    }

    public void Sesefektcikar(int hangises)
    {
        sesefektleri[hangises].Stop();
        sesefektleri[hangises].Play();
    }

    public void Karisiksesefektcikar(int hangises)
    {
        sesefektleri[hangises].Stop();
        sesefektleri[hangises].pitch = Random.Range(0.8f, 1.3f);
        sesefektleri[hangises].Play();
    }
}
