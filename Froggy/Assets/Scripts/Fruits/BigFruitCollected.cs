using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFruitCollected : MonoBehaviour
{
    public static bool cherry;
    public static bool strawberry;
    public static bool banana;
    void Start()
    {
        cherry = false;
        strawberry = false;
        banana = false;
    }
    void Update()
    {
        if (cherry)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (strawberry)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (banana)
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
    }
}
