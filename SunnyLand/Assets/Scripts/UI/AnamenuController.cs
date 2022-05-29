using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnamenuController : MonoBehaviour
{
    public string sahneAdi;
    public void Oyunabasla()
    {
        SceneManager.LoadScene(sahneAdi);
    }
    public void OyundanCikis()
    {
        Application.Quit();
    }
}
