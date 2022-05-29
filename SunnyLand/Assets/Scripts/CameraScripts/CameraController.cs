using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform hedefTransform;

    [SerializeField]
    float minY, maxY, minX, maxX;

    [SerializeField]
    Transform ust, orta;


    Vector2 sonPos;

    private void Start()
    {
        sonPos = transform.position;
    }

    private void Update()
    {
        KamerayýsinirlaF();
        ZeminhareketetF();
    }

    void KamerayýsinirlaF()
    {
        transform.position = new Vector3(Mathf.Clamp(hedefTransform.position.x, minX, maxX), Mathf.Clamp(hedefTransform.position.y, minY, maxY), transform.position.z);
    }
    void ZeminhareketetF()
    {
        Vector2 aradakimiktar = new Vector2(transform.position.x - sonPos.x, transform.position.y - sonPos.y);

        ust.position += new Vector3(aradakimiktar.x, aradakimiktar.y, 0f);
        orta.position += new Vector3(aradakimiktar.x, aradakimiktar.y, 0f)*.5f;
        sonPos = transform.position;
    }
}
