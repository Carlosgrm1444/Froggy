using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    public static float fruitsCant;
    public float Total;
    void Start()
    {
        Total = transform.childCount;
    }
    void Update()
    {
        fruitsCant = transform.childCount;
        TextApple.contadorApple = Total - fruitsCant;
    }
}
