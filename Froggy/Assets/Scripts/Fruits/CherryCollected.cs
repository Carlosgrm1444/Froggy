﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryCollected : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            BigFruitCollected.cherry = true;
            Destroy(gameObject, 0.5f);
        }
    }
}
