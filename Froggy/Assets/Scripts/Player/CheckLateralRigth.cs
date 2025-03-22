using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLateralRigth : MonoBehaviour
{
    public static bool LateralRight = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Lateral") && !CheckGround.isGrounded)
        {
            LateralRight = true;
            FlipPlayer.anim.SetBool("Lateral", true);
            FlipPlayer.sp.flipX = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Lateral"))
        {
            LateralRight = false; 
            FlipPlayer.anim.SetBool("Lateral", false);
            FlipPlayer.sp.flipX = true;
        }
    }
}
