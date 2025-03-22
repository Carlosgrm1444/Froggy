using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLateralLefth : MonoBehaviour
{
    public static bool LateralLefth = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lateral") &&!CheckGround.isGrounded)
        {
            LateralLefth = true;
            FlipPlayer.anim.SetBool("Lateral", true);
            FlipPlayer.sp.flipX = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Lateral"))
        {
            LateralLefth = false;
            FlipPlayer.anim.SetBool("Lateral", false);
            FlipPlayer.sp.flipX = false;
        }
    }
}
