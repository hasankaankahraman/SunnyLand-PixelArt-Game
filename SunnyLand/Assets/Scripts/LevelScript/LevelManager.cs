using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    PlayerController playerController;

    private void Awake()
    {
        instance = this;
        playerController = Object.FindObjectOfType<PlayerController>();
    }
    public int toplananelmassayisi;

    public void SahneyiBitir()
    {
        playerController.hareketetsinmi = false;
        SceneManager.LoadScene("MainMenu");

    }
}
