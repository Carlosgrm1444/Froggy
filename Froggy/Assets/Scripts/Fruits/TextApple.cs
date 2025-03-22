using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextApple : MonoBehaviour
{
    public static float contadorApple;

    void Update()
    {
        GetComponent<Text>().text = ("= " + contadorApple.ToString());
    }
}
