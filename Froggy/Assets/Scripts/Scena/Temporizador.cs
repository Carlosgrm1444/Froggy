 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temporizador : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] Text tiempo;

    private float restante;
    private bool adelante;
    private bool stop;

    public PlayerMove health;

    private void Awake()
    {
        restante = (min * 60) + seg;
        adelante = true;
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }

    private void Update()
    {
        if (adelante && !stop)
        {
            restante -= Time.deltaTime;
            if (restante <  1)
            {
                health.instaKill();
                stop = true;
            }
            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            tiempo.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);

        }
    }
}
