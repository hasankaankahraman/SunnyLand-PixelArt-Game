using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    Image kalp1_Img, kalp2_Img, kalp3_Img;

    [SerializeField]
    Sprite dolukalp, boskalp,yarimkalp;

    

    [SerializeField]
    TMP_Text elmastxt;
    HealthController healthController;
    LevelManager levelmanager;

    private void Awake()
    {
        healthController = Object.FindObjectOfType<HealthController>();
        levelmanager = Object.FindObjectOfType<LevelManager>();
    }
    public void Saglikdurumunuguncelle()
    {
        switch (healthController.gecerlisaglik)
        {
            case 6:
                kalp1_Img.sprite = dolukalp;
                kalp2_Img.sprite = dolukalp;
                kalp3_Img.sprite = dolukalp;
                break;

            case 5:
                kalp1_Img.sprite = dolukalp;
                kalp2_Img.sprite = dolukalp;
                kalp3_Img.sprite = yarimkalp;
                break;

            case 4:
                kalp1_Img.sprite = dolukalp;
                kalp2_Img.sprite = dolukalp;
                kalp3_Img.sprite = boskalp;
                break;

            case 3:
                kalp1_Img.sprite = dolukalp;
                kalp2_Img.sprite = yarimkalp;
                kalp3_Img.sprite = boskalp;
                break;

            case 2:
                kalp1_Img.sprite = dolukalp;
                kalp2_Img.sprite = boskalp;
                kalp3_Img.sprite = boskalp;
                break;

            case 1:
                kalp1_Img.sprite = yarimkalp;
                kalp2_Img.sprite = boskalp;
                kalp3_Img.sprite = boskalp;
                break;

            case 0:
                kalp1_Img.sprite = boskalp;
                kalp2_Img.sprite = boskalp;
                kalp3_Img.sprite = boskalp;
                break;

        }
    }

    public void Elmassayisinigüncelle()
    {
        elmastxt.text = levelmanager.toplananelmassayisi.ToString();
    }
}
