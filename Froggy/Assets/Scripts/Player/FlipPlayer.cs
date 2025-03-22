using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipPlayer : MonoBehaviour
{
    public static SpriteRenderer sp;
    public static Animator anim;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
}
