using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class efektmanager : MonoBehaviour
{

    [SerializeField]
    float yasamasuresi;

    private void Start()
    {
        Destroy(gameObject, yasamasuresi);
    }
}
