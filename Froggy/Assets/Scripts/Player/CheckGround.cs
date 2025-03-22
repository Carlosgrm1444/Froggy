using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Grounded") || collision.CompareTag("Lateral"))
        {
            isGrounded = true;
            Debug.Log("fall");
        }
    }
    private void OnTriggerSstay2D(Collider2D collision)
    {
        if (collision.CompareTag("Grounded") || collision.CompareTag("Lateral"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Grounded") || collision.CompareTag("Lateral"))
        {
            isGrounded = false;
        }
    }
}
