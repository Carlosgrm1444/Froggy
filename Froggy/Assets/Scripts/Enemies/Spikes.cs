using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float cantidad  = 1f;

    public PlayerMove health;
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            health.quitarVida(cantidad);
            FlipPlayer.anim.SetBool("Daño", true);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            health.quitarVida(cantidad);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        FlipPlayer.anim.SetBool("Daño", false);
    }
}
