using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corazones : MonoBehaviour
{
    public static bool heart1;
    public static bool heart2;
    public static bool heart3;
    public static bool heart4;
    public static bool heart5;
    public static bool heart6;
    void Start()
    {

    }
    void Update()
    {
        switch (PlayerMove.health)
        {
            case 0f:
                heart1 = false;
                heart2 = false;
                heart3 = false;
                heart4 = false;
                heart5 = false;
                heart6 = false;
                break;
            case 1f:
                heart1 = false;
                heart2 = true;
                heart3 = false;
                heart4 = false;
                heart5 = false;
                heart6 = false;
                break;
            case 2f:
                heart1 = true;
                heart2 = false;
                heart3 = false;
                heart4 = false;
                heart5 = false;
                heart6 = false;
                break;
            case 3f:
                heart1 = true;
                heart2 = false;
                heart3 = false;
                heart4 = true;
                heart5 = false;
                heart6 = false;
                break;
            case 4f:
                heart1 = true;
                heart2 = false;
                heart3 = true;
                heart4 = false;
                heart5 = false;
                heart6 = false;
                break;
            case 5f:
                heart1 = true;
                heart2 = false;
                heart3 = true;
                heart4 = false;
                heart5 = false;
                heart6 = true;
                break;
            case 6f:
                heart1 = true;
                heart2 = false;
                heart3 = true;
                heart4 = false;
                heart5 = true;
                heart6 = false;
                break;
            default:
                Debug.Log("ERROR");
                break;
        }
        if (heart1)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (heart2)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (heart3)
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
        if (heart4)
        {
            gameObject.transform.GetChild(3).gameObject.SetActive(true);
        }
        if (heart5)
        {
            gameObject.transform.GetChild(4).gameObject.SetActive(true);
        }
        if (heart6)
        {
            gameObject.transform.GetChild(5).gameObject.SetActive(true);
        }
        if (!heart1)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        if (!heart2)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        if (!heart3)
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
        if (!heart4)
        {
            gameObject.transform.GetChild(3).gameObject.SetActive(false);
        }
        if (!heart5)
        {
            gameObject.transform.GetChild(4).gameObject.SetActive(false);
        }
        if (!heart6)
        {
            gameObject.transform.GetChild(5).gameObject.SetActive(false);
        }
    }
}
