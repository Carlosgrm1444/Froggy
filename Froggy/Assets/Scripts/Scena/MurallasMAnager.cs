using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurallasMAnager : MonoBehaviour
{
    bool level1 = false;
    bool level2 = false;
    void Start()
    {
        if (PlayerPrefs.GetInt("LeveClear1") >= 1)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            level1 = true;
        }
        if (PlayerPrefs.GetInt("LeveClear2") >= 1)
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            level2 = true;
        }



        if (level1 && level2)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    void Update()
    {
    }
}
